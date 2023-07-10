using System.ComponentModel.DataAnnotations;

namespace CodeBridge.Models
{
    public class DogForCreationDTO
    {
        [Required(ErrorMessage = "Define the Name")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Color { get; set; } = string.Empty;

        [Required]
        public int TailLength { get; set; }

        [Required]
        public int Weight { get; set; }
    }
}
