using System;
using Core.Utilities.Helpers.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelperService
    {
        public IResult Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<string> Update(IFormFile file, string filePath, string root)
        {
            var result = Delete(filePath);
            if (result.Success)
            {
                return Upload(file, root);
            }
            return new ErrorDataResult<string>();
        }

        public IDataResult<string> Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }


                string extension = Path.GetExtension(file.FileName);
                var extensionValid = ChechIfImageExtensionValid(extension);

                if (!extensionValid.Success)
                {
                    return new ErrorDataResult<string>(message:extensionValid.Message);
                }

                string guid = Guid.NewGuid().ToString();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return new SuccessDataResult<string>(data:filePath);
                }
            }
            return new ErrorDataResult<string>();
        }

        private IResult ChechIfImageExtensionValid(string extension)
        {
            foreach (var ext in FileHelperMessages.Extensions)
            {
                if(extension == ext)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult(FileHelperMessages.WrongExtension);
        }
    }
}