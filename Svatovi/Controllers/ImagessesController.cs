using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;
using Svatovi.Models;
using Svatovi.Repository;
using static System.Reflection.Metadata.BlobBuilder;

namespace Svatovi.Controllers
{
    public class ImagessesController : Controller
    {
        private readonly IImageRepository _imageRepository=null;

        public readonly IWebHostEnvironment _webHostEnviroment;

        public ImagessesController(IImageRepository imageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _imageRepository= imageRepository;
            _webHostEnviroment = webHostEnvironment;

                }
        [Route("all-guests")]
        public async Task<ViewResult>GetAllImage()
        {
            var data= await _imageRepository.GetAllImages();

            return View(data);
        }
        [Route("image-guest/{id:int:min(1)}")]
        public async Task<ViewResult>GetImage(int id)
        {
            var data = await _imageRepository.GetImageById(id);

            return View(data);
        }

        public async Task<ViewResult>AddNewimage(int ImageId = 0)
        {
            var model = new ImagessModel();
            ViewBag.ImageId = ImageId;
            return View(model);
        }

        private async Task<IActionResult> AddNewimage(ImagessModel imagemodel)
        {

            if (imagemodel.Gallerys! == null)
            {
                string folder = "image/gallery/";
                imagemodel.Gallerys = new List<GalleryModel>();
                foreach(var file in imagemodel.Gallerys) {
                    var gallery = new GalleryModel()
                    {
                        Name = file.Name,
                        URL = file.URL
                    };
                    imagemodel.Gallerys.Add(gallery);

                }
            }
            return View();
        }

        private async Task<string>UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder= Path.Combine(_webHostEnviroment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }

         
    }

   
}
