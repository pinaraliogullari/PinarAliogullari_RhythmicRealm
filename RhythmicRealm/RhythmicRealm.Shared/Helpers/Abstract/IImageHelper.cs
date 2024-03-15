using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.Helpers.Abstract
{
    public interface IImageHelper
    {
        Task<string> UploadImage(IFormFile image, string folderName);
        bool IsValidImage(string extension);
    }
}
