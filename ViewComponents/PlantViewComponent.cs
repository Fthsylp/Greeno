using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.ViewComponents
{
    public class PlantViewComponent : ViewComponent
    {
        private readonly IPlantContainerRepository plantContainerRepository;

        public PlantViewComponent(IPlantContainerRepository plantContainerRepository)
        {
            this.plantContainerRepository = plantContainerRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var plantItems = await plantContainerRepository.GetAllAsync();
            return View(plantItems);
        }
    }
}
