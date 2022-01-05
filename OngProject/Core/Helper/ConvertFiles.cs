using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Helper
{
    public class ConvertFiles
    {
        public static IFormFile BinaryToFormFile(byte[] bytes, FormFileData formFileData)
        {
            MemoryStream stream = new MemoryStream(bytes);

            IFormFile file = new FormFile(stream, 0, bytes.Length, formFileData.Name, formFileData.FileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = formFileData.ContentType
            };

            stream.Close();

            return file;
        }

    }
}
