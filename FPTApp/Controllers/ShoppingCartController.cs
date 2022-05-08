using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTApp.Models;

namespace FPTApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        FPTDBContext fPTDB = new FPTDBContext();
        // GET: ShoppingCart
        
        public PartialViewResult CartItem()
        {
            int _item = 0;
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            if(cart != null)
            {
                _item = cart.Total_Quantity();
            }

            ViewBag.infocart = _item;
            return PartialView("CartItem");
        }


        public ShoppingCart GetCart()
        {
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            if (cart == null || Session["ShoppingCart"] == null)
            {
                cart = new ShoppingCart();
                Session["ShoppingCart"] = cart;
            }
            return cart;
        }

        // Add method to card
        public ActionResult AddToCart(Guid? id)
        {
            var aBook = fPTDB.Books.SingleOrDefault(s => s.BookID == id);
            if (aBook != null)
            {
                GetCart().Add(aBook);
            }
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        //cart page
        public ActionResult ShowToCart()
        {
            if (Session["ShoppingCart"] == null)
            {
                return RedirectToAction("ShowToCart", "ShoppingCart");
            }
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            return View(cart);
        }

        public ActionResult UpdateQuantity (FormCollection form)
        {
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            Guid id_pro = Guid.Parse(form["ID Book"]) ;
            decimal quantity = Decimal.Parse(form["Quantity"]);
            cart.UpdateQuantity(id_pro, quantity);
            return RedirectToAction("ShowToCart", "ShoppingCart");
        }

        public ActionResult RemoveCart (Guid id)
        {
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            cart.DeleleItemInCart(id);
            return RedirectToAction("ShowToCart", "ShoppingCart");
                
                
        }

        public PartialViewResult BagCart()
        {
            int total_item = 0;
            ShoppingCart cart = Session["ShoppingCart"] as ShoppingCart;
            if (cart!= null)
            
                total_item = cart.Total_Quantity();
                ViewBag.QuantityCart = total_item;
                return PartialView("BagCart");
            
            
        }
    }
}