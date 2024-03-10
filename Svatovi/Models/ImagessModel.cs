using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svatovi.Models
{
    public class ImagessModel
    {

        public int Id { get; set; }
        //public string Image { get; set; }
        public string Coment { get; set; }

        [NotMapped]
        [DisplayName("Odaberi sliku")]
        public IFormFileCollection? Imagefile { get; set; }

        public List <GalleryModel> GalleryModels { get; set; }
    }
}
