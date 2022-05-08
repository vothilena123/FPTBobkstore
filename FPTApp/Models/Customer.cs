using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPTApp.Models
{
    public class Customer
    {
        [Required]
        public Guid IDCus { get; set; }

        [Key]
        public int CodeCus { get; set; }

        [Required]
        public string Email_Cus { get; set; }

        [Required]
        public string Phone_Cus { get; set; }

        [Required]
        public ICollection<Order> Orders {get; set;}
    }
}