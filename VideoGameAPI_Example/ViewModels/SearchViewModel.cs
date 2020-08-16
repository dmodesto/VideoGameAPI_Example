using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.ViewModels
{
    public class SearchViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public String Name { get; set; }
        public String GenresJSON { get; set; }
        public String PlatformsJSON { get; set; }
    }
}