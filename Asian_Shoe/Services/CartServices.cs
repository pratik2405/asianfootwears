using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepo repo;
        public CartServices(ICartRepo repo)
        {
            this.repo = repo;
        }
        public int AddtoCart(Cart cart)
        {
            return repo.AddtoCart(cart);
        }

        public int Delete(int id )
        {
           return repo.Delete(id);
        }

        public int DeleteAll(IEnumerable<Cart> carts)
        {
            return repo.DeleteAll(carts);
        }

        public IEnumerable<Cart> GetCartById(int id)
        {
            return repo.GetCartById(id);
        }

        public IEnumerable<Cart> GetCarts()
        {
           return repo.GetCarts();
        }

        public int savedb()
        {
            return repo.savedb();
        }

        public int Update(Cart cart)
        {
            return repo.Update(cart);
        }
    }
}
