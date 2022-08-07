using System;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelperService
    {
        IDataResult<string> Upload(IFormFile file, string root);
        IResult Delete(string filePath);
        IDataResult<string> Update(IFormFile file, string filePath, string root);
    }
}