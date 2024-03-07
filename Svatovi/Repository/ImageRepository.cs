using Microsoft.EntityFrameworkCore;
using Svatovi.Areas.Identity.Data;
using Svatovi.Data;
using Svatovi.Models;
using System.Drawing;

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
            var newimage = new ImagessModel()
            {
                Image = imagess.Image,
                Coment = imagess.Coment
            };

            newimage.Gallerys = new List<GalleryModel>();


            foreach (var file in imagess.Gallerys)
            {
                newimage.Gallerys.Add(new GalleryModel()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }
            await _context.Datas.AddAsync(newimage);
            await _context.SaveChangesAsync();
            return newimage.Id;
        }

        public async Task<List<ImagessModel>> GetAllImages()
        {
            return await _context.Datas.Select(i => new ImagessModel()
            {
                Id = i.Id,
                Coment = i.Coment,
                Image = i.Image
            }).ToListAsync();

        }

        public async Task<ImagessModel> GetImageById(int id)
        {
            return await _context.Datas.Where(x => x.Id == id)
                .Select(image => new ImagessModel()
            {
                Id = image.Id,
                Image = image.Image,
                Coment = image.Coment,

                Gallerys = image.Gallerys.Select(x => new GalleryModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    URL = x.URL
                }).ToList(),
            }).FirstOrDefaultAsync();
        }
    }
}
