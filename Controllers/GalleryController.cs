using Greeno.Models.Domain;
using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IGalleryRepository galleryRepository;

        public GalleryController(IGalleryRepository galleryRepository)
        {
            this.galleryRepository = galleryRepository;
        }

        public async Task<IActionResult> List()
        {
            var gallery = await galleryRepository.GetAllAsync();
            return View(gallery);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Gallery gallery)
        {
            var newImage = new Gallery { Image = gallery.Image };

            await galleryRepository.AddAsync(newImage);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var currentImage = await galleryRepository.GetByIdAsync(id);

            if (currentImage != null)
            {
                var editImage = new Gallery
                {
                    Id = currentImage.Id,
                    Image = currentImage.Image,
                };

                return View(editImage);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Gallery gallery)
        {
            var currentImage = new Gallery
            {
                Id = gallery.Id,
                Image = gallery.Image,
            };

            var updatedImage = await galleryRepository.UpdateAsync(currentImage);

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Gallery gallery)
        {
            var deletedImage = await galleryRepository.DeleteAsync(gallery.Id);
            if (deletedImage != null)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Edit", new { id = gallery.Id });
            }

        }

    }
}