using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameAPI_Example.Models;
using VideoGameAPI_Example.ViewModels;

namespace VideoGameAPI_Example.Controllers
{
    public class GameController : Controller
    {
        private ApplicationDbContext _context;

        public GameController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Route("game/{Id}")]
        public ActionResult Index(GameViewModel game)
        {
            game.GenresJSON = JsonConvert.SerializeObject(
                _context.Genres.Select(g => new
                    {
                        Id = g.Id,
                        Name = g.Name
                    }
                )
            );

            game.PlatformsJSON = JsonConvert.SerializeObject(
                _context.Platforms.Select(p => new
                    {
                        Id = p.Id,
                        Name = p.Name
                    }
                )
            );

            return View(game);
        }
    }
}