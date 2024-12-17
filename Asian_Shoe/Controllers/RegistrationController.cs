using Asian_Shoe.Models;
using Asian_Shoe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asian_Shoe.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationServices services;
        private readonly IRoleServices roleServices;
        public RegistrationController(IRegistrationServices services, IRoleServices roleServices)
        {
            this.services = services;
            this.roleServices = roleServices;
        }
        // GET: RegistrationController
        public ActionResult Index()
        {
            
            var res = services.GetAllUser();
            return View(res);
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {    var res=services.GetById(id);
            return View(res);
        }

        // GET: RegistrationController/Create
        //---------------------- Registration -----------------------------------------------------
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration user)
        {
            try
            {
                var res = services.AddUser(user);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View("Create");
                }
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage=e.Message;
                return View();
            }
        }

        //---------------------- Login-----------------------------------------------------

        public ActionResult Login()
        {
            return View();
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            try
            {
                var res = services.Login(email, password);
                if (res !=null)
                {
                    if (res.role_id == 1)
                    {
                        HttpContext.Session.SetInt32("Admin", res.role_id);
                        HttpContext.Session.SetString("Admin",res.First_name);
                        HttpContext.Session.SetInt32("user_id", res.User_id);
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        HttpContext.Session.SetString("Customer", res.First_name);
                        HttpContext.Session.SetInt32("user_id", res.User_id);
                        return RedirectToAction("DisplayProduct", "DisplayProducts");
                    }
                }
                else
                {
                    ViewBag.Error = "Incorrect password or email";
                    return View("Login");
                }
                
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Role = roleServices.GetRoles();
            var res=services.GetById(id);
            return View(res);
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration registration)
        {
            try
            {
                var res = services.UpdateUser(registration);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "Something went wrong !";
                    return View("Index");
                }
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            var res= services.GetById(id);
            return View(res);
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var res=services.DeleteUser(id);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error= "Something went wrong !";
                    return View("Index");
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
