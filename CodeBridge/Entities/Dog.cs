using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CodeBridge.Entities
{
    [DataContract]
    public class Dog : IEquatable<Dog>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [Required]
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "color", EmitDefaultValue = false)]
        public string? Color { get; set; }

        [DataMember(Name = "tail_length", EmitDefaultValue = false)]
        public int TailLength { get; set; }

        [DataMember(Name = "weight", EmitDefaultValue = false)]
        public int Weight { get; set; }

        public Dog(string name)
        {
            Name = name;
        }

        public bool Equals(Dog? other)
        {
            if (other == null)
                return false;

            return Name == other.Name
                && Color == other.Color
                && TailLength == other.TailLength
                && Weight == other.Weight;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Dog);
        }
    }
}
