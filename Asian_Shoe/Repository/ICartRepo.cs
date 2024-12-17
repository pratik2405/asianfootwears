using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public interface ICartRepo
    {
        public IEnumerable<Cart>GetCarts();

        public IEnumerable<Cart>GetCartById(int id);

        public int AddtoCart(Cart cart);

        

        public int Update(Cart cart);

        public int Delete(int id);

        public int DeleteAll( IEnumerable<Cart> carts);
        public int savedb();
    }
}
