using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class CartRepo : ICartRepo
    {
        private readonly ApplicationDbContext db;
        public CartRepo(ApplicationDbContext db)
        {
            this.db = db;  
        }
        public int AddtoCart(Cart cart)
        {
            int result = 0;
            db.Carts.Add(cart);
            result=db.SaveChanges();
            return result;
        }

        public int Delete(Cart cart)
        {
            int result = 0;
            var res = db.Carts.Where(x => x.Product_id == cart.Product_id).SingleOrDefault();
            if (res != null)
            {
                db.Carts.Remove(res);
                result=db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Cart> GetCartById(int id)
        {
            var res = from c in db.Carts
                      join u in db.Registrations on c.User_id equals u.User_id
                      join p in db.Products
                      on c.Product_id equals p.Product_id
                      where c.User_id == id
                      select new Cart
                      {
                          Cart_id = c.Cart_id,
                          User_id = c.User_id,
                          Product_id = c.Product_id,
                          Quantity = c.Quantity,
                          Price = p.Price,
                          Product_Name = p.Product_name
                      };
            return res;
        }

        public IEnumerable<Cart> GetCarts()
        {
            //int userid = HttpContext.Session.GetInt32("user_id");
          
            var res = from c in db.Carts
                      join u in db.Registrations on c.User_id equals u.User_id
                      join p in db.Products
                      on c.Product_id equals p.Product_id
                      select new Cart
                      {
                          Cart_id=c.Cart_id,
                          User_id = c.User_id,
                          Product_id = c.Product_id,
                          Quantity = c.Quantity,
                          Price = p.Price,
                          Product_Name = p.Product_name
                      };
            return res;
        }

        public int Update(Cart cart)
        {
            int result = 0;

            var res=db.Carts.Where(x=>x.User_id == cart.User_id).SingleOrDefault();

            if(res != null)
            {
                res.Product_id = cart.Product_id;
                res.User_id = cart.User_id;
                res.Quantity=cart.Quantity;

                result=db.SaveChanges();
            }
            return result;
        }
    }
}
