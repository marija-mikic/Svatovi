using System.Drawing;

namespace Svatovi.Data
{
    public class Gallery
    {
        public int Id { get; set; }
        public int ImageId {  get; set; }
        public string Name { get; set; }

        public string URL { get; set; }

        public Image Image { get; set; }
    }
}
