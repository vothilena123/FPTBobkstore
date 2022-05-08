using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPTApp.Models
{
    public class Order
    {
        [Key]
        public string OrderID { get; set; }

        [Required]
        public System.DateTime OrderDate { get; set; }

        [Required]
        public string OrderNumber { get; set; }
    }
}