using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.ViewModels
{
    public class SearchViewModel
    {
        public String Name { get; set; }
        public String GenresJSON { get; set; }
        public String PlatformsJSON { get; set; }
    }
}