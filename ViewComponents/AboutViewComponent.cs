using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutRepository aboutRepository;

        public AboutViewComponent(IAboutRepository aboutRepository)
        {
            this.aboutRepository = aboutRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var aboutItems = await aboutRepository.GetAllAsync();
            return View(aboutItems);
        }
    }
}
