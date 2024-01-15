using System.ComponentModel.DataAnnotations;

namespace platforma.Models.ViewModels
{
    public class AddAnimalRequest
    {
        public string Name { get; set; }

        public string Species { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsAvailableForAdoption { get; set; }

        
        public int Age { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }
    }
}
