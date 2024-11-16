using Greeno.Models.Domain;
using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.Controllers
{
    public class CarouselController : Controller
    {
        private readonly ICarouselRepository carouselRepository;

        public CarouselController(ICarouselRepository carouselRepository)
        {
            this.carouselRepository = carouselRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var carousels = await carouselRepository.GetAllAsync();
            return View(carousels);
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Carousel carousel) 
        {
            var newCarousel = new Carousel
            {
                Title = carousel.Title,
                SubTitle = carousel.SubTitle,
                Description = carousel.Description,
                Image = carousel.Image,
            };

            await carouselRepository.AddAsync(newCarousel);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit (Guid id) 
        {
            var currentCarousel = await carouselRepository.GetByIdAsync(id);

            if (currentCarousel != null) {
                var editCarousel = new Carousel
                {
                    Id = currentCarousel.Id,
                    Title = currentCarousel.Title,
                    SubTitle = currentCarousel.SubTitle,
                    Description = currentCarousel.Description,
                    Image = currentCarousel.Image,
                };

                return View(editCarousel);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (Carousel carousel) 
        {
            var currentCarousel = new Carousel
            {
                Id = carousel.Id,
                Title = carousel.Title,
                SubTitle = carousel.SubTitle,
                Description = carousel.Description,
                Image = carousel.Image,
            };

            var updatedCarousel = await carouselRepository.UpdateAsync(currentCarousel);

            return RedirectToAction("Edit",new {id = carousel.Id});
        }

        [HttpPost]
        public async Task<IActionResult> Delete (Carousel carousel) 
        {
            var deletedCarousel = await carouselRepository.DeleteAsync(carousel.Id);
            if (deletedCarousel != null) {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Edit", new { id = carousel.Id });
            }
        }


    }
}
