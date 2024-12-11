using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        Product GetProductByName(string name);

        int AddProduct(Product prod);


        int UpdateProduct(Product prod);

        int DeleteProductById(Product prod);

    }
}
