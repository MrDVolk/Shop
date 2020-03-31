using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Enter your name")]
        [StringLength(25)]
        [Required(ErrorMessage = "Name Length need to be at least 5 letters long")]
        public string Name { get; set; }

        [Display(Name = "Enter your surname")]
        [StringLength(25)]
        [Required(ErrorMessage = "Surname Length need to be at least 5 letters long")]
        public string Surname { get; set; }

        [Display(Name = "Enter your adress")]
        [StringLength(35)]
        [Required(ErrorMessage = "Adress Length need to be at least 10 letters long")]
        public string Adress { get; set; }

        [Display(Name = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Phone number need to be at least 8 digits long")]
        public string Phone { get; set; }

        [Display(Name = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Email need to be at least 5 symbols long")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }

    }
}
