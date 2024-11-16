using Greeno.Models.Domain;
using Greeno.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Greeno.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var contacts = await contactRepository.GetAllAsync();
            return View(contacts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Contact contact)
        {
            var newContact = new Contact
            {
                Title = contact.Title,
                Image = contact.Image,
            };

            await contactRepository.AddAsync(newContact);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var currentContact = await contactRepository.GetByIdAsync(id);

            if (currentContact != null)
            {
                var editContact = new Contact
                {
                    Id = currentContact.Id,
                    Title = currentContact.Title,
                    Image = currentContact.Image,
                };

                return View(editContact);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Contact contact)
        {
            var currentContact = new Contact
            {
                Id = contact.Id,
                Title = contact.Title,
                Image = contact.Image
            };

            var updatedContact = await contactRepository.UpdateAsync(currentContact);

            return RedirectToAction("List");
            //return RedirectToAction("Edit", new { id = contact.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Contact contact)
        {
            var deletedContact = await contactRepository.DeleteAsync(contact.Id);
            if (deletedContact != null)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Edit", new { id = contact.Id });
            }
        }
    }
}
