using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoGameAPI_Example.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        [StringLength(255)]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(255)]
        public String LastName { get; set; }

        [Required]
        [StringLength(255)]
        public String Email { get; set; }

        [Required(ErrorMessage = "A message is required.")]
        [Display(Name = "Message")]
        [StringLength(511)]
        public String MessageText { get; set; }

        public DateTime? MessageDate { get; set; }
    }
}