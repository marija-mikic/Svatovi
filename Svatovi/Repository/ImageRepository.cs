using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Svatovi.Areas.Identity.Data;
using Svatovi.Data;
using Svatovi.Models;
using System.Linq;
using Image = Svatovi.Data.Image;

namespace Svatovi.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly SvatoviContext _context = null;


        public ImageRepository(SvatoviContext context)
        {
            _context = context;

        }

        public async Task<int> AddNewImage(ImagessModel imagess)
        {
            var newImage = new Image()
            {
                Coment = imagess.Coment


            };

            newImage.imageGalleries = new List<ImageGallery>();


            foreach (var file in imagess.GalleryModels)
            {
                newImage.imageGalleries.Add(new ImageGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }
            await _context.Datas.AddAsync(newImage);
            await _context.SaveChangesAsync();
            return newImage.Id;
        }





        public async Task<List<ImagessModel>> GetAllImages()
        {
            return await _context.Datas.Select(i => new ImagessModel()
            {
                Id = i.Id,
                Coment = i.Coment,
                GalleryModels = i.imageGalleries.Select(g => new GalleryModel()
                {
                    Name = g.Name,
                    URL = g.URL,
                }).ToList()

            }).ToListAsync();



        }


        public async Task<ImagessModel?> GetImageById(int id)
        {
            return await _context.Datas.Where(x => x.Id == id)
                .Select(image => new ImagessModel()
                {
                    Id = image.Id,
                    //Image = image.Images,
                    Coment = image.Coment,

                    GalleryModels = image.imageGalleries.Select(x => new GalleryModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        URL = x.URL
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}