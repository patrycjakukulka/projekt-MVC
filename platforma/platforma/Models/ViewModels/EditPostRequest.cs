using System.ComponentModel.DataAnnotations;

namespace platforma.Models.ViewModels
{
    public class EditPostRequest
    {
        public Guid Id { get; set; }

        public string AnimalName { get; set; }

        public string AnimalDescription { get; set; }

        public string FeaturedImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        public bool Visible { get; set; }
    }
}
