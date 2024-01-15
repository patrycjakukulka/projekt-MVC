namespace platforma.Models.Domain
{
    public class PostAnimal
    {
        public Guid Id { get; set; }
        public string AnimalName { get; set; }
        public string AnimalDescription { get; set;}
        public string FeaturedImageUrl { get; set; }
        public DateTime PublishedDate { get; set; }

        public bool Visible { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
