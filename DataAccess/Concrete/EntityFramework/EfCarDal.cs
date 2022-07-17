using System;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands!
                             on c.BrandId equals b.BrandId
                             join co in context.Colors!
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { CarName=c.CarName, BrandName=b.BrandName, 
                                                    ColorName=co.ColorName, DailyPrice=c.DailyPrice};
                return result.ToList();
            }
            
        }
    }
}