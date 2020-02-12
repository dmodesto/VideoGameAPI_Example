using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.Models
{
    public class Platform
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Abbreviation { get; set; }
        public string Slug { get; set; }
        public int PlatformLogoId { get; set; }
    }
}