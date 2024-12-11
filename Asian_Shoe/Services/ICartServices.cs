using Asian_Shoe.Models;

namespace Asian_Shoe.Services
{
    public interface ICartServices
    {
        public IEnumerable<Cart> GetCarts();
        public IEnumerable<Cart> GetCartById(int id);

        public int AddtoCart(Cart cart);

        public int Update(Cart cart);

        public int Delete(Cart cart);
    }
}
