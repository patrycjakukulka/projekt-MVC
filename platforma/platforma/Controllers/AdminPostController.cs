using Microsoft.AspNetCore.Mvc;
using platforma.Data;
using platforma.Models.Domain;
using platforma.Models.ViewModels;

namespace platforma.Controllers
{
    public class AdminPostController : Controller
    {

        private readonly PlatformaDbContext _context;

        public AdminPostController(PlatformaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            var posts = _context.PostAnimals.ToList();
            return View(posts);
        }

        [HttpPost]
        public IActionResult Add(AddPostRequest model)
        {
            
            if (ModelState.IsValid)
            {
                var post = new PostAnimal
                {
                    AnimalName = model.AnimalName,
                    AnimalDescription = model.AnimalDescription,
                    FeaturedImageUrl = model.FeaturedImageUrl,
                    PublishedDate = model.PublishedDate,
                    Visible = model.Visible
                };

                _context.PostAnimals.Add(post);
                _context.SaveChanges();

                return RedirectToAction("List"); 
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var post = _context.PostAnimals.FirstOrDefault(x => x.Id == id);
            if (post != null)
            {
                var editPostRequest = new EditPostRequest
                {
                    Id = post.Id,
                    AnimalName = post.AnimalName,
                    AnimalDescription = post.AnimalDescription,
                    FeaturedImageUrl = post.FeaturedImageUrl,
                    PublishedDate = post.PublishedDate,
                    Visible = post.Visible
                };
                return View(editPostRequest);
            }

            return View(null);
        }

        [HttpPost]
        public IActionResult Edit(EditPostRequest editPostRequest)
        {
            var post = new PostAnimal
            {
                Id = editPostRequest.Id,
                AnimalName = editPostRequest.AnimalName,
                AnimalDescription = editPostRequest.AnimalDescription,
                FeaturedImageUrl = editPostRequest.FeaturedImageUrl,
                PublishedDate = editPostRequest.PublishedDate,
                Visible = editPostRequest.Visible
            };

            var existingPost = _context.PostAnimals.Find(post.Id);
            if (existingPost != null)
            {
                existingPost.AnimalName = post.AnimalName;
                existingPost.AnimalDescription = post.AnimalDescription;
                existingPost.FeaturedImageUrl = post.FeaturedImageUrl;
                existingPost.PublishedDate = post.PublishedDate;
                existingPost.Visible = post.Visible;

                _context.SaveChanges();
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editPostRequest.Id });
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(Guid id)
        {
            
            var postToDelete = _context.PostAnimals.Find(id);

            if (postToDelete != null)
            {
                
                _context.PostAnimals.Remove(postToDelete);
                _context.SaveChanges();

                return RedirectToAction("List"); 
            }

            return RedirectToAction("Edit", new { id }); 
        }

    }
}
