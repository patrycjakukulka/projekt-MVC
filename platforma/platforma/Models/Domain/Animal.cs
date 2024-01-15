using System.ComponentModel.DataAnnotations;

namespace platforma.Models.Domain
{
    public class Animal
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Species { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailableForAdoption { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Age must be a non-negative number.")]
        public int Age { get; set; } 

        public string Gender { get; set; }

        public string City { get; set; }
        public ICollection<PostAnimal> PostAnimals { get; set; }
    }
}
