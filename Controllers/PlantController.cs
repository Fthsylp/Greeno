using Greeno.Models.Domain;
using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantContainerRepository plantRepository;

        public PlantController(IPlantContainerRepository plantRepository)
        {
            this.plantRepository = plantRepository;
        }

        public async Task<IActionResult> List()
        {
            var plants = await plantRepository.GetAllAsync();
            return View(plants);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(PlantContainer plantContainer)
        {
            var newPlant = new PlantContainer
            {
                Image = plantContainer.Image,
                Title = plantContainer.Title,
                Description = plantContainer.Description,

            };
            await plantRepository.AddAsync(newPlant);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var currentPlant = await plantRepository.GetByIdAsync(id);

            if (currentPlant != null)
            {
                var editPlant = new PlantContainer
                {
                    Id = currentPlant.Id,
                    Image = currentPlant.Image,
                    Title = currentPlant.Title,
                    Description = currentPlant.Description,
                };
                return View(editPlant);
            }
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PlantContainer plantContainer)
        {
            var currentPlant = new PlantContainer
            {
                Id = plantContainer.Id,
                Image = plantContainer.Image,
                Title = plantContainer.Title,
                Description = plantContainer.Description,
            };

            var updatedPlant = await plantRepository.UpdateAsync(currentPlant);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PlantContainer plantContainer)
        {
            var deletedPlant = await plantRepository.DeleteAsync(plantContainer.Id);

            if (deletedPlant != null)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Edit", new { id = plantContainer.Id });
            }
        }
    }
}