using Microsoft.AspNetCore.Http;
using RhythmicRealm.Shared.Helpers.Abstract;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RhythmicRealm.Shared.Helpers.Concrete
{
  
    public class ImageHelper : IImageHelper
    {

        //bu constructor sayesinde ImageHelper nesnesi her oluştuğunda otomatik olarak localhost:5000/wwwroot/images oluşacak.Artık elimizde dosyaları kaydetmek için kullanacağımız klasörün temel bölümü mevcut.
        //IWebHostEnvironment containerda hazırda bekleyen bir servis.dolayısıyla program.cs e herhangi bir kod eklemedim. 
        private readonly string _basePath;

        public ImageHelper(IWebHostEnvironment _environment) 
        {
            _basePath = Path.Combine(_environment.WebRootPath, "images");
        }

        public bool IsValidImage(string extension)
        {
            string[] correctExtension = { ".png", ".jpg", ".jpeg" };
            if (correctExtension.Contains(extension))
            {
                return true;
            }
            return false;

        }


        //bu metot dışarıdan gelen imagei belirtilen foldername e sahip bir klasöre kaydeder ve geriye filename döner.
        public async Task<string> UploadImage(IFormFile image, string folderName)
        {
            if (image == null)
            {
                return null;
            }
            var fileExtension = Path.GetExtension(image.FileName); //gelen resim pino.png ise .png kısmını alacak.
            if (!IsValidImage(fileExtension))
            {
                return "";
            }
            //verdiğimiz foldername e göre directory oluşur.
            // localhost:5000/wwwroot/images/products
            var targetFolder = Path.Combine(_basePath, folderName); //directory

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }


            var fileName = $"{Guid.NewGuid()}{fileExtension}";//skjfhskjdfhksj.png
            var fileFullPath = Path.Combine(targetFolder, fileName); //localhost:5000/wwwroot/images/products/skjfhskjdfhksj.png
            await using (var stream = new FileStream(fileFullPath, FileMode.Create))
            {
                image.CopyTo(stream); 
            }
            return fileName;
        }
    }
}
