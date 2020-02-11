using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoGameAPI_Example.Controllers
{
    public class TopGamesController : Controller
    {
        // GET: TopGames
        public ActionResult Index()
        {
            return View();
        }
    }
}