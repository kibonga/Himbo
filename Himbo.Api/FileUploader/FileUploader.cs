using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Himbo.Api.FileUpload
{
    public class FileUploader : IFileUploader
    {
        private static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".png", ".jpeg" };

        public void Remove(string path)
        {

        }

        public List<string> UploadMany(List<IFormFile> files)
        {
            #region File Names List
            var fileNames = new List<string>();
            #endregion

            #region Upload each File Name
            files.ForEach(file =>
                {
                    fileNames.Add(Upload(file));
                }); 
            #endregion

            return fileNames;
        }

        public string Upload(IFormFile file)
        {
            #region Create File Parts
            var guid = Guid.NewGuid().ToString();
            var extension = Path.GetExtension(file.FileName);
            #endregion

            #region Validate
            if (!AllowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException("Unsupported file type.");
            }
            #endregion

            #region Create File Name
            string fileName = guid + extension;
            #endregion

            #region Create Path 
            var filePath = Path.Combine("wwwroot", "images", fileName);
            #endregion

            #region Create File Stream
            using var stream = new FileStream(filePath, FileMode.Create);
            #endregion

            #region Copy File to target Stream
            file.CopyTo(stream);
            #endregion

            return fileName;
        }
    }
}
