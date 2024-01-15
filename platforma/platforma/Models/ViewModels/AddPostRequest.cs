using Microsoft.AspNetCore.Mvc.Rendering;

namespace platforma.Models.ViewModels
{
    public class AddPostRequest
    {
        public string AnimalName { get; set; }
        public string AnimalDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }

        public bool Visible { get; set; }

    }
}
