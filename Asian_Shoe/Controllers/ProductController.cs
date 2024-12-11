using Asian_Shoe.Models;
using Asian_Shoe.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asian_Shoe.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductServices services;
        private readonly ICategoryServices cat;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment env;
        public ProductController(IProductServices services, ICategoryServices cat, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.services = services; 
            this.cat=cat;
            this.env = env;
        }


//===================================================================================================================================
        // GET: ProductController
        public ActionResult Index()
        {
            var res=services.GetAllProduct();
            return View(res);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Category=cat.GetCategories();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product prod,IFormFile file )
        {   
            try
            {
                //to upload img in folder product_images
                using (var fs = new FileStream(env.WebRootPath + "\\image\\" + file.FileName, FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fs);
                }
                prod.Image_Url="~/image/"+ file.FileName;

                var res=services.AddProduct(prod);
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
                ViewBag.ErrorMessage = e.Message;
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Category = cat.GetCategories();
            var res=services.GetProductById(id);
            TempData["oldUrl"] = res.Image_Url;
            TempData.Keep("oldUrl");
            return View(res);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product prod,IFormFile file)
        {
            try
            {
                string oldimgurl = TempData["oldUrl"].ToString();

                if (file != null)
                {
                    using (var fs = new FileStream(env.WebRootPath + "\\image\\" + file.FileName, FileMode.Create, FileAccess.Write))
                    {
                        file.CopyTo(fs);
                    }

                    //to store img url only in database
                    prod.Image_Url = "~/image/" + file.FileName;

                    //to delect old image 
                    string[] str = oldimgurl.Split("/");
                    string str1 = (str[str.Length - 1]);
                    string path = env.WebRootPath + "\\image\\" + str1;
                    System.IO.File.Delete(path);
                }
                else
                {
                    prod.Image_Url = oldimgurl;
                }

                var res = services.UpdateProduct(prod);
                if (res == 1)
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = services.GetProductById(id);
            return View(res);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult ComfirmDelete(Product prod)
        {
            try
            {
                var res=services.DeleteProductById(prod);
                if (res>=1)
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
    }
}
