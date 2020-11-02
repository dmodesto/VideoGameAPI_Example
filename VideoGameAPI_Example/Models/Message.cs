using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        [StringLength(511)]
        public String MessageText { get; set; }

        public DateTime? MessageDate { get; set; }
    }
}