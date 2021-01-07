using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameAPI_Example.Models;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers
{
    public class ContactController : Controller
    {
        private ApplicationDbContext _context;

        public ContactController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // no model for the contact index
        public ActionResult Index()
        {
            var viewModel = new ContactViewModel();
            return View(viewModel);
        }

        // Save the contact and message information
        [HttpPost]
        public ActionResult SaveContact(ContactViewModel contact)
        {
            var viewModel = new ContactViewModel
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MessageText = contact.MessageText,
                MessageDate = DateTime.Now
            };

            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }


            var dbContact = _context.Contacts.SingleOrDefault(c => c.Email == viewModel.Email);

            if (dbContact != null)
            {
                contact.Id = dbContact.Id;
            }
            else
            {
                var newContact = new Contact
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email
                };

                _context.Contacts.Add(newContact);
            }

            var newMessage = new Message
            {
                ContactId = contact.Id,
                MessageText = viewModel.MessageText,
                MessageDate = viewModel.MessageDate
            };

            _context.Messages.Add(newMessage);

            _context.SaveChanges();

            return View(viewModel);
        }
    }
}