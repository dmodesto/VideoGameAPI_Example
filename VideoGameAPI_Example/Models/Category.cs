using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Platform> platforms { get; set; }
    }
}