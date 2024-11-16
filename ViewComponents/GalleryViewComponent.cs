using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.ViewComponents
{
    public class GalleryViewComponent : ViewComponent
    {
        private readonly IGalleryRepository galleryRepository;

        public GalleryViewComponent(IGalleryRepository galleryRepository)
        {
            this.galleryRepository = galleryRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var galleryItems = await galleryRepository.GetAllAsync();
            return View(galleryItems);
        }
    }
}
