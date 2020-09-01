using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameAPI_Example.Models;
using VideoGameAPI_Example.ViewModels;
using Newtonsoft.Json;

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
            var viewModel = new SelectOptionsViewModel
            {
                CategoryId = selectOptions.CategoryId,
                PlatformId = selectOptions.PlatformId,
                GameEngineId = selectOptions.GameEngineId,
                Categories = _context.Categories.ToList(),
                Platforms = _context.Platforms.ToList(),
                GameEngines = _context.GameEngines.ToList()
            };

            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            // CategoryId isn't required so set it to 0 if null
            if (viewModel.CategoryId == null)
            {
                viewModel.CategoryId = 0;
            }

            // Grab the platform name
            String platformName = viewModel.Platforms.Where(g => g.Id == viewModel.PlatformId).First().Name;

            // GameEngineId isn't required so set it to 0 if null
            // otherwise grab the Game Engines name
            GameEngine gameEngine;
            String gameEngineName = "";

            if (viewModel.GameEngineId == null)
            {
                viewModel.GameEngineId = 0;
            }
            else
            {
                gameEngine = viewModel.GameEngines.Where(g => g.Id == viewModel.GameEngineId).First();

                if (gameEngine != null)
                {
                    gameEngineName = gameEngine.Name;
                }
            }

            var getGamesViewModel = new GetGamesViewModel
            {
                CategoryId = viewModel.CategoryId,
                PlatformId = viewModel.PlatformId,
                GameEngineId = viewModel.GameEngineId,
                PlatformName = platformName,
                GameEngineName = gameEngineName,
                //Categories = viewModel.Categories.ToList(),
                //Platforms = viewModel.Platforms.ToList(),
                //GameEngines = viewModel.GameEngines.ToList(),
                GenresJSON = JsonConvert.SerializeObject(_context.Genres.ToList()),
                PlatformsJSON = JsonConvert.SerializeObject(
                    viewModel.Platforms.Select(p => new
                        {
                            Id = p.Id,
                            Name = p.Name
                        }
                    )
                )
            };

            return View(getGamesViewModel);
        }
    }
}