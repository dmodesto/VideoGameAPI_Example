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
    public class TopGamesController : Controller
    {
        private ApplicationDbContext _context;

        public TopGamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // provide select options to be used when querying IDGB api
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();
            var platforms = _context.Platforms.Include(p => p.Category).ToList();
            var gameEngines = _context.GameEngines.ToList();

            var view = new SelectOptionsViewModel
            {
                //CategoryId = 0,
                //PlatformId = 0,
                //GameEngineId = 0,
                Categories = categories,
                Platforms = platforms,
                GameEngines = gameEngines
            };

            return View(view);
        }

        // Use the Web Api to return IGDB game results
        [HttpPost]
        public ActionResult GetGames(SelectOptionsViewModel selectOptions)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SelectOptionsViewModel
                {
                    CategoryId = selectOptions.CategoryId,
                    PlatformId = selectOptions.PlatformId,
                    GameEngineId = selectOptions.GameEngineId,
                    Categories = _context.Categories.ToList(),
                    Platforms = _context.Platforms.ToList(),
                    GameEngines = _context.GameEngines.ToList()
                };

                return View("Index", viewModel);
            }

            return View();
        }
    }
}