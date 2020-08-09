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
    public class SearchController : Controller
    {
        private ApplicationDbContext _context;

        public SearchController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // Use the Web Api to return IGDB game results
        [HttpPost]
        public ActionResult GetGames(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            viewModel.GenresJSON = JsonConvert.SerializeObject(_context.Genres.ToList());
            viewModel.PlatformsJSON = JsonConvert.SerializeObject(
                    _context.Platforms.Select(p => new
                    {
                        Id = p.Id,
                        Name = p.Name
                    }
                    )
                );

            return View(viewModel);
        }

        //// Use the Web Api to return IGDB game results
        //[HttpPost]
        //public ActionResult GetGames(string gameTitle)
        //{
        //    if (gameTitle == null || gameTitle.Length == 0)
        //    {
        //        return View("Index");
        //    }

        //    var getGamesViewModel = new SearchViewModel
        //    {
        //        Name = gameTitle,
        //        GenresJSON = JsonConvert.SerializeObject(_context.Genres.ToList()),
        //        PlatformsJSON = JsonConvert.SerializeObject(
        //            _context.Platforms.Select(p => new
        //            {
        //                Id = p.Id,
        //                Name = p.Name
        //            }
        //            )
        //        )
        //    };

        //    return View(getGamesViewModel);
        //}
    }
}