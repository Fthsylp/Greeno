using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.ViewComponents
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly IContactRepository contactRepository;

        public ContactViewComponent(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactItems = await contactRepository.GetAllAsync();
            return View(contactItems);
        }

    }
}
