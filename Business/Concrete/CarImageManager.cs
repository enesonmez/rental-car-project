using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }


        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var fileHelperResult = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            if (fileHelperResult.Success)
            {
                carImage.ImagePath = fileHelperResult.Data;
                carImage.CreateDate = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.UploadImage);
            }
            return new ErrorResult();
            
        }

        public IResult Delete(CarImage carImage)
        {
            var fileHelperResult = _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            if (fileHelperResult.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.ImageDeleted);
            }
            return new ErrorResult();
            
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarImageExists(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.CarImageId==id));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var fileHelperResult = _fileHelper.Update(formFile, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            if (fileHelperResult.Success)
            {
                carImage.ImagePath = fileHelperResult.Data;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.ImageUpdated);
            }
            return new ErrorResult();            
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarImageExists(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImages = new List<CarImage>();

            carImages.Add(new CarImage { CarId = carId, CreateDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImage>>(carImages);
        }
    }
}