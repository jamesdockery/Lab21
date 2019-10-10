using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }




        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }




        [Required(ErrorMessage ="Last Name is required")]
        public string LastName { get; set; }



        
        [Required(ErrorMessage ="User Name is required")]
        [StringLength(10, MinimumLength = 3)]

        public string UserName { get; set; }



        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


     
        [Required(ErrorMessage ="Password is required")]
            [DataType(DataType.Password)]
        [MinLength(3)]
        [MaxLength(10)]
        public string Password { get; set; }


        [Required(ErrorMessage ="Confirm Password is required")]
        [Compare("Password", ErrorMessage ="Passwords must match")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }

       
    }
}
