using Svatovi.Models;

namespace Svatovi.Repository
{
    public interface IImageRepository
    {
        Task<int> AddNewImage(ImagessModel imagess);

        Task<List<ImagessModel>> GetAllImages();

        Task<ImagessModel>GetImageById(int id);

    }
}
