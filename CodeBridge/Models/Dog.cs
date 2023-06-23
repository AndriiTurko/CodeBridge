using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CodeBridge.Models
{
    [DataContract]
    public class Dog : IEquatable<Dog>
    {
        [Key, DataMember(Name = "id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "color", EmitDefaultValue = false)]
        public string Color { get; set; }

        [DataMember(Name = "tail_length", EmitDefaultValue = false)]
        public int Tail_length { get; set; }

        [DataMember(Name = "weight", EmitDefaultValue = false)]
        public int Weight { get; set; }

        public bool Equals(Dog? other)
        {
            if (other == null)
                return false;

            return this.Name == other.Name
                && this.Color == other.Color
                && this.Tail_length == other.Tail_length
                && this.Weight == other.Weight;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Dog);
        }
    }
}
