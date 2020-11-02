using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [StringLength(255)]
        public String FirstName { get; set; }

        [StringLength(255)]
        public String LastName { get; set; }

        [StringLength(255)]
        public String Email { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}