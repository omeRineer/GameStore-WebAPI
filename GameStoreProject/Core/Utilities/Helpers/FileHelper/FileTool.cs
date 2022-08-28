using Core.Utilities.ResultTool;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileTool : IFileTool
    {
        private readonly FileOptions FileOptions;

        public FileTool(IOptions<FileOptions> fileOptions)
        {
            FileOptions = fileOptions.Value;
        }

        public IResult Delete(string fileName)
        {
            string extension = GetExtensionToUpper(fileName);
            string fullPath = Path.Combine(FileOptions.BasePath, extension, fileName);

            if (File.Exists(fullPath)) File.Delete(fullPath);

            return new SuccessResult("File deleted is success");

        }

        public IDataResult<string> Upload(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string newFileName = NewFileName(extension);
            string directory = Path.Combine(FileOptions.BasePath, GetExtensionToUpper(extension));
            string fullPath = Path.Combine(directory, newFileName);

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return new SuccessDataResult<string>(data: newFileName);
        }

        public IDataResult<List<string>> UploadCollection(IFormFileCollection fileCollection)
        {
            var fileNames = new List<string>();
            foreach (var file in fileCollection)
            {
                var uploadResult=Upload(file);
                if (!uploadResult.Success)
                {
                    return new ErrorDataResult<List<string>>();
                }
                fileNames.Add(uploadResult.Data);
            }
            return new SuccessDataResult<List<string>>(data:fileNames);
        }

        public string GetExtensionToUpper(string fileName)
        {
            return Path.GetExtension(fileName)
                        .Trim('.')
                        .ToUpper();
        }

        private string NewFileName(string fileExtension)
        {
            return $"{Guid.NewGuid()}{fileExtension}";
        }
    }
}
