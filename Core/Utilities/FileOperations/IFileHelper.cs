using System;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.FileOperations
{
    public interface IFileHelper
    {
        IDataResult<string> Upload(IFormFile file, string root);
        IResult Delete(string filePath);
        IDataResult<string> Update(IFormFile file, string filePath, string root);
    }
}