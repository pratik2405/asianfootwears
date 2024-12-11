using Asian_Shoe.Models;
using Asian_Shoe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Asian_Shoe.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartServices cart_services;
        private readonly IProductServices prod_services;
        public CartController(ICartServices cart_services, IProductServices prod_services)
        {
            this.cart_services = cart_services;
            this.prod_services = prod_services;
        }
        // GET: CartController
        public ActionResult Index()
        {
            int userid = (int)HttpContext.Session.GetInt32("user_id");
            var res = cart_services.GetCartById(userid);
            return View(res);
        }

        [HttpGet]
        public IActionResult AddToCart(int productId)
        {
            try
            {
                if (productId == 0)
                {
                    ViewBag.Error = "Invalid product ID.";
                    return RedirectToAction("DisplayProduct", "DisplayProducts");
                }

                int userid = (int)HttpContext.Session.GetInt32("user_id");

                var res = prod_services.GetProductById(productId);
                if (res != null)
                {
                    cart_services.AddtoCart(new Cart
                    {
                        Product_id = res.Product_id,
                        User_id = userid,
                        Price = res.Price,
                        Product_Name = res.Product_name,
                        Quantity = 1
                    });
                    return RedirectToAction("Index", "Cart");
                }
                else
                {
                    ViewBag.Error = "Error to add product into cart !";
                    return RedirectToAction("DisplayProduct", "DisplayProducts");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("DisplayProduct", "DisplayProducts");

            }
        }

    }
       
    }

