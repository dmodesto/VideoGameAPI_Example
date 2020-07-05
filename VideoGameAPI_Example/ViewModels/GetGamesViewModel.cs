using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoGameAPI_Example.Models;

namespace VideoGameAPI_Example.ViewModels
{
    public class GetGamesViewModel
    {
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Display(Name = "Platform")]
        public int PlatformId { get; set; }

        [Display(Name = "Game Engine")]
        public int? GameEngineId { get; set; }

        //public List<GameEngine> GameEngines { get; set; }
        //public List<Category> Categories { get; set; }
        //public List<Platform> Platforms { get; set; }
        //public List<Genre> Genres { get; set; }

        public String GenresJSON { get; set; }
        public String PlatformsJSON { get; set; }
    }
}