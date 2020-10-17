using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.Models
{
    public class AccessToken
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public int ExpiresIn { get; set; }
    }
}