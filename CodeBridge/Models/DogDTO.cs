using System.ComponentModel.DataAnnotations;

namespace CodeBridge.Models
{
    public class DogDTO
    {
        public string Name { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public int Tail_length { get; set; }

        public int Weight { get; set; }
    }
}
