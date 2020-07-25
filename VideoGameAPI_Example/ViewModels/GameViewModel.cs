using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string Genres { get; set; }
        public string Platforms { get; set; }
        public string Summary { get; set; }
        public float? TotalRating { get; set; }
        public string Url { get; set; }
        public int? CoverId { get; set; }
        public string CoverUrl { get; set; }

        public String GenresJSON { get; set; }
        public String PlatformsJSON { get; set; }
    }
}