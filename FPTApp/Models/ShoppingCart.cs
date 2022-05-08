using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FPTApp.Models
{
    public class BookInCart
    {
        //book in cart
        public Book product { get; set; }
        public decimal Quantity { get; set; }


    }
    public class ShoppingCart
    {

        List<BookInCart> items = new List<BookInCart>();

        public IEnumerable<BookInCart> Items
        {
            get { return items; }

        }

        public void Add(Book _book, decimal quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.product.BookID == _book.BookID);
            if (item == null)
            {
                items.Add(new BookInCart
                {
                    product = _book,
                    Quantity = quantity

                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void UpdateQuantity (Guid? id, decimal quantity)
        {
            var item = items.Find(s => s.product.BookID == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public decimal TotalMoney()
        {
            var total = items.Sum(s => s.product.BookPrice * s.Quantity);
            return total;
        }

        public void DeleleItemInCart(Guid? id)
        {
            items.RemoveAll(s => s.product.BookID == id);
        }

        public int Total_Quantity()
        {
            return (int)items.Sum(s => s.Quantity);
        }

        public void ClearCart()
        {
            items.Clear(); // delete cart
        }
    }


    

    


}