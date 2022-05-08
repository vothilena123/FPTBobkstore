using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPTApp.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }
        [Required]
        public int OrderID { get; set; }

        [Required]
        public Guid BookID { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal Total { get; set; }
    }
}