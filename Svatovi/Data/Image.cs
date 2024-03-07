namespace Svatovi.Data
{
    public class Image
    {

        public int Id {  get; set; }
        public string Images { get; set; }

        public string Coment { get; set; }

        public ICollection<ImageGallery> imageGalleries { get; set; }   




    }
}
