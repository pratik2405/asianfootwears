using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public interface IProductRepo
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        IEnumerable<Product> GetProductByName(string name);

        IEnumerable<Product> GetAllProductsByCategory(int id);

        int AddProduct(Product prod);


        int UpdateProduct(Product prod);

        int DeleteProductById(Product prod);

    }
}
