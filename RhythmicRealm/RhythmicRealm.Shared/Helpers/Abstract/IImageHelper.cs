using Microsoft.AspNetCore.Http;

namespace RhythmicRealm.Shared.Helpers.Abstract
{
	public interface IImageHelper
    {
        Task<string> UploadImage(IFormFile image, string folderName);
        bool IsValidImage(string extension);
    }
}
