using Asian_Shoe.Data;
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
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        private readonly IPurchaseServices purchase_Services;
        private readonly IPurchaseDetailsServices purchase_detail_services;
        private readonly ApplicationDbContext db;


        public CartController(ApplicationDbContext db,ICartServices cart_services, IProductServices prod_services, Microsoft.AspNetCore.Hosting.IHostingEnvironment env,IPurchaseServices purchase_Services, IPurchaseDetailsServices purchase_detail_services)
        {
            this.cart_services = cart_services;
            this.prod_services = prod_services;
            this.env = env;
            this.purchase_Services = purchase_Services;
            this.purchase_detail_services = purchase_detail_services;
            this.db = db;
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

        public IActionResult UpdateQuantity(Cart cart)
        {
            try
            {
                int userid = (int)HttpContext.Session.GetInt32("user_id");
                var res = cart_services.Update(cart);
                if (res != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error to  update quantity !";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }

        public IActionResult Delete(int id )
        {
            try
            {
                var res = cart_services.Delete(id);
                if (res >= 1)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error to  delete cart !";
                    return View("Index");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }

        public IActionResult PlaceOrder()
        {
            try
            {
                int userid = (int)HttpContext.Session.GetInt32("user_id");
                var cartitems = cart_services.GetCartById(userid);

                if (cartitems == null || !cartitems.Any())
                {
                    TempData["Error"] = "Your cart is empty!";
                    return RedirectToAction("Index");
                }

                using (var transaction = db.Database.BeginTransaction())
                {
                    foreach (var item in cartitems)
                    {
                        var purchase = new Purchase
                        {
                            User_id = userid,
                            product_id = item.Product_id,
                            Quantity = item.Quantity
                        };

                        purchase_Services.AddPurchase(purchase);
                        purchase_Services.savedb();

                        var latestPurchase = db.Purchases
                               .OrderByDescending(p => p.Purchase_id) 
                               .FirstOrDefault();

                        var purchaseDetail = new PurchaseDetails
                        {
                            purchase_id = latestPurchase.Purchase_id,
                            user_id = latestPurchase.User_id,
                            product_id = latestPurchase.product_id,
                            status_id=1,
                            TotalAmt = latestPurchase.Quantity * item.Price
                        };

                        purchase_detail_services.Add(purchaseDetail);
                        purchase_detail_services.SaveDb();
                    }

                    cart_services.DeleteAll(cartitems);
                    cart_services.savedb();
                    transaction.Commit();
                }

                TempData["Success"] = "Your order has been placed successfully!";
                return RedirectToAction("OrderConfirmation");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"An error occurred: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }

    }
       
    }

