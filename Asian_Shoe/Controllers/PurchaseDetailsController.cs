using Asian_Shoe.Models;
using Asian_Shoe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asian_Shoe.Controllers
{
    public class PurchaseDetailsController : Controller
    {
        private readonly IPurchaseDetailsServices services;
        private readonly IStatusServices statusServices;
        private readonly IRoleServices roleServices;
        private readonly IRegistrationServices registrationServices;
        private readonly IProductServices productServices;
      
        public PurchaseDetailsController(IPurchaseDetailsServices services, IStatusServices statusServices, IRegistrationServices registrationServices, IProductServices productServices)
        {
            this.services = services;
            this.statusServices = statusServices;
            this.roleServices = roleServices;
            this.registrationServices = registrationServices;
            this.productServices = productServices;
        }
        // GET: PurchaseDetailsController
        public ActionResult Index()
        {
            ViewBag.Product = productServices.GetAllProduct().ToDictionary(p => p.Product_id, p => p.Product_name);
            ViewBag.User = registrationServices.GetAllUser().ToDictionary(u => u.User_id, u => u.First_name);
            var res=services.GetAll();
            return View(res);
        }

        // GET: PurchaseDetailsController/Details/5
        public ActionResult Details(int id)
        {
            var res = services.GetByPurchaseId(id);
            return View(res);
        }

        public IActionResult UserPurchase()
        {
            int userid = (int)HttpContext.Session.GetInt32("user_id");
            var res=services.GetByUserId(userid);
            ViewBag.Status = statusServices.GetStatuses();
            return View(res);
        }

        // GET: PurchaseDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PurchaseDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Status = statusServices.GetStatuses();
            var res=services.GetByPurchaseId(id);
            return View(res);
        }

        // POST: PurchaseDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PurchaseDetails details)
        {
            try
            {
                var res=services.Update(details);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View();
                }
            }
            catch(Exception e)
            {
                ViewBag.Error=e.Message;
                return View();
            }
        }

        // GET: PurchaseDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PurchaseDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
