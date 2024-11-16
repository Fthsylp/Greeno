using Greeno.Models.Domain;
using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutRepository aboutRepository;

        public AboutController(IAboutRepository aboutRepository)
        {
            this.aboutRepository = aboutRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var abouts = await aboutRepository.GetAllAsync();
            return View(abouts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(About about)
        {
            var newAbout = new About
            {
                Title = about.Title,
                Description = about.Description,
                Satisfaction = about.Satisfaction,
                FreeDelivery = about.FreeDelivery,
                StoreLocators = about.StoreLocators,
            };

            await aboutRepository.AddAsync(newAbout);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var currentAbout = await aboutRepository.GetByIdAsync(id);

            if (currentAbout != null)
            {
                var editAbout = new About
                {
                    Id = currentAbout.Id,
                    Title = currentAbout.Title,
                    Description = currentAbout.Description,
                    Satisfaction = currentAbout.Satisfaction,
                    FreeDelivery = currentAbout.FreeDelivery,
                    StoreLocators = currentAbout.StoreLocators,
                };

                return View(editAbout);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about)
        {
            var currentAbout = new About
            {
                Id = about.Id,
                Title = about.Title,
                Description = about.Description,
                Satisfaction = about.Satisfaction,
                FreeDelivery = about.FreeDelivery,
                StoreLocators = about.StoreLocators,
            };

            var updatedAbout = await aboutRepository.UpdateAsync(currentAbout);

            return RedirectToAction("Edit", new { id = about.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(About about)
        {
            var deletedAbout = await aboutRepository.DeleteAsync(about.Id);
            if (deletedAbout != null)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Edit", new { id = about.Id });
            }
        }
    }
}
