using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        [Display(Name = "First name")]
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]        
        [Required]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required]
        public string Email { get; set; }
    }
}
