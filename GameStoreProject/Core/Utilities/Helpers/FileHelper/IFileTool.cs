using Core.Utilities.ResultTool;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileTool
    {
        IDataResult<string> Upload(IFormFile file);
        IDataResult<List<string>> UploadCollection(IFormFileCollection fileCollection);

        IResult Delete(string filePath);
    }
}