using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.ViewComponents
{
    public class CarouselViewComponent : ViewComponent
    {
        private readonly ICarouselRepository carouselRepository;

        public CarouselViewComponent(ICarouselRepository carouselRepository)
        {
            this.carouselRepository = carouselRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var carouselItems = await carouselRepository.GetAllAsync();
            return View(carouselItems);
        }
    }
}
