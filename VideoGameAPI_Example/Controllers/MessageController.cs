using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameAPI_Example.Models;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private ApplicationDbContext _context;

        public MessageController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // /Message/
        public ActionResult Index()
        {
            IEnumerable<Message> messages = _context.Messages.Include(c => c.Contact).ToList();
            var view = new MessageViewModel
            {
                Messages = messages
            };

            return View(view);
        }

        // /Message/Remove/5 
        public ActionResult Remove(int id)
        {
            var message = _context.Messages.Single(m => m.Id == id);

            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }

            IEnumerable<Message> messages = _context.Messages.Include(c => c.Contact).ToList();
            var view = new MessageViewModel
            {
                Messages = messages
            };

            return View("Index", view);
        }
    }
}