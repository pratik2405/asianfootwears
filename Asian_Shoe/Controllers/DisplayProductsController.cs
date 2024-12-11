using Asian_Shoe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asian_Shoe.Controllers
{
    public class DisplayProductsController : Controller
    {
        private readonly IProductServices services;
        private readonly ICategoryServices cat;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public DisplayProductsController(IProductServices services, ICategoryServices cat, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.services = services;
            this.cat = cat;
            this.env = env;
        }

        //Display Product
        public IActionResult DisplayProduct()
        {
            var res = services.GetAllProduct();
            return View(res);
        }

        public IActionResult AddCart(int id)
        {
            return View();
        }
        // GET: DisplayProductsController/Details/5
        public ActionResult Details(int id)
        {
            var res=services.GetProductById(id);
            return View(res);
        }


        // GET: DisplayProductsController
        public ActionResult Index()
        {
            return View();
        }

        
        // GET: DisplayProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisplayProductsController/Create
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

        // GET: DisplayProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisplayProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DisplayProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisplayProductsController/Delete/5
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
