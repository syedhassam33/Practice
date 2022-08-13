using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace PokemonAPI.Models
{
    public class Pokemon_Table
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? Files { get; set; } = null;
        [NotMapped]
        public byte[]? ImgByte { get; set; }

        public string? Description { get; set; }
    }
}
