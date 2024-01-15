using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using platforma.Data;
using platforma.Models.ViewModels;

namespace platforma.Controllers
{
    public class UserController : Controller
    {
        private readonly PlatformaDbContext _context;

        public UserController(PlatformaDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public IActionResult List()
        {
            var animals = _context.Animals.ToList();
            return View("List", animals);
        }
        
        [HttpGet]
        public IActionResult ShowPost()
        {
            var userPosts = _context.PostAnimals.ToList(); 
            return View("ShowPost", userPosts);
        }
    }
}
