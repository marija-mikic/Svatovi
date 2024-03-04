using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Svatovi.Models
{
    public class Imagess
    {

        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Coment { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile Imagefile { get; set; }
    }
}
