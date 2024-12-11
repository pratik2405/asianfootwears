using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext db;
        public ProductRepo(ApplicationDbContext db)
        {
            this.db = db; 
        }
        public int AddProduct(Product prod)
        {
            int result = 0;
            db.Products.Add(prod);
            result=db.SaveChanges();
            return result;
        }

        public int DeleteProductById(Product prod)
        {
            int result = 0;
            var res=db.Products.Where(x=>x.Product_id==prod.Product_id).SingleOrDefault();

            if(res!=null)
            {
                db.Products.Remove(res);
                result=db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            var res=(from p in db.Products
                    join c in db.Categories on p.Category_id equals c.Category_id
                    select new Product
                    {
                        Product_id = p.Product_id,
                        Product_name = p.Product_name,
                        Description = p.Description,
                        Category_id=p.Category_id,
                        Category_name=c.Category_name,
                        Price=p.Price,
                        Image_Url=p.Image_Url,
                        Stock=p.Stock
                    }).ToList();
            return res;
        }

        public Product GetProductById(int id)
        {
            var res = (from p in db.Products
                       join c in db.Categories on p.Category_id equals c.Category_id
                       where p.Product_id == id
                       select new Product
                       {
                           Product_id = p.Product_id,
                           Product_name = p.Product_name,
                           Description = p.Description,
                           Category_id = p.Category_id,
                           Category_name = c.Category_name,
                           Price = p.Price,
                           Image_Url=p.Image_Url,
                           Stock=p.Stock
                       }).FirstOrDefault();
            return res;
        }

        public Product GetProductByName(string name)
        {
            var res = (from p in db.Products
                       join c in db.Categories on p.Category_id equals c.Category_id
                       where p.Product_name == name
                       select new Product
                       {
                           Product_id = p.Product_id,
                           Product_name = p.Product_name,
                           Description = p.Description,
                           Category_id = p.Category_id,
                           Category_name = c.Category_name,
                           Price = p.Price,
                           Image_Url=p.Image_Url,
                           Stock=p.Stock
                       }).FirstOrDefault();
            return res;
        }

        public int UpdateProduct(Product prod)
        {
            int result = 0;
            var res = db.Products.Where(x => x.Product_id == prod.Product_id).SingleOrDefault();

            if(res != null)
            {
                res.Product_name = prod.Product_name;
                res.Description = prod.Description;
                res.Category_id = prod.Category_id;
                res.Price = prod.Price;
                res.Image_Url = prod.Image_Url;
                res.Stock=prod.Stock;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
