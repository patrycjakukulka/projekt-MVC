using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using platforma.Data;
using platforma.Models.Domain;
using platforma.Models.ViewModels;
namespace platforma.Controllers
{
    public class AddAnimalController : Controller
    {
        private readonly PlatformaDbContext platformaDbContext;

        public AddAnimalController(PlatformaDbContext platformaDbContext)
        {
            this.platformaDbContext = platformaDbContext;
        }

       
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        
        [HttpPost]
        [ActionName("Add")]
        public IActionResult SubmitAdd(AddAnimalRequest addAnimalRequest)
        {
            var animal = new Animal
            {
                Name = addAnimalRequest.Name,
                Species = addAnimalRequest.Species,
                Description = addAnimalRequest.Description,
                ImageUrl = addAnimalRequest.ImageUrl,
                Age = addAnimalRequest.Age,
                IsAvailableForAdoption = addAnimalRequest.IsAvailableForAdoption,
                Gender = addAnimalRequest.Gender,
                City = addAnimalRequest.City
            };
            platformaDbContext.Animals.Add(animal);
            platformaDbContext.SaveChanges();

            return RedirectToAction("List");
        }
        
        [HttpGet]
        [ActionName("List")]
        public IActionResult List()
        {
            var animal = platformaDbContext.Animals.ToList();


            return View(animal);
        }

        
        [HttpGet]
        [ActionName("Edit")]
        public IActionResult Edit(Guid id)
        {

            var animal = platformaDbContext.Animals.FirstOrDefault(x => x.Id == id);
            if (animal != null)
            {
                var editAnimalRequest = new EditAnimalRequest
                {
                    Name = animal.Name,
                    Species = animal.Species,
                    Description = animal.Description,
                    ImageUrl = animal.ImageUrl,
                    IsAvailableForAdoption = animal.IsAvailableForAdoption,
                    Age = animal.Age,
                    Gender = animal.Gender,
                    City = animal.City
                };
                return View(editAnimalRequest);
            }

            return View(null);
        }

        
        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(EditAnimalRequest editAnimalRequest)
        {
            var animal = new Animal
            {
                Id = editAnimalRequest.Id,
                Name = editAnimalRequest.Name,
                Species = editAnimalRequest.Species,
                Description = editAnimalRequest.Description,
                ImageUrl = editAnimalRequest.ImageUrl,
                IsAvailableForAdoption = editAnimalRequest.IsAvailableForAdoption,
                Gender = editAnimalRequest.Gender,
                Age = editAnimalRequest.Age,
                City = editAnimalRequest.City
            };
            var existingAnimal = platformaDbContext.Animals.Find(animal.Id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = animal.Name;
                existingAnimal.Species = animal.Species;
                existingAnimal.Description = animal.Description;
                existingAnimal.ImageUrl = animal.ImageUrl;
                existingAnimal.IsAvailableForAdoption = animal.IsAvailableForAdoption;
                existingAnimal.Age = animal.Age;
                
                existingAnimal.City = animal.City;

                platformaDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editAnimalRequest.Id });
        }
       
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete(EditAnimalRequest editAnimalRequest)
        {
            var animal = platformaDbContext.Animals.Find(editAnimalRequest.Id);
            if (animal != null)
            {
                platformaDbContext.Animals.Remove(animal);
                platformaDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return RedirectToAction("Edit", new { id = editAnimalRequest.Id });
        }
    }
}
