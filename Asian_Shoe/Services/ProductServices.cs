using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepo repo;

        public ProductServices(IProductRepo repo)
        {
            this.repo = repo; 
        }
        public int AddProduct(Product prod)
        {
            return repo.AddProduct(prod);
        }

        public int DeleteProductById(Product prod)
        {
            return repo.DeleteProductById(prod);
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return repo.GetAllProduct();
        }

        public IEnumerable<Product> GetAllProductsByCategory(int id)
        {
           return repo.GetAllProductsByCategory(id);
        }

        public Product GetProductById(int id)
        {
            return repo.GetProductById(id);
        }

        public IEnumerable<Product> GetProductByName(string name)
        {
            return repo.GetProductByName(name);
        }

        public int UpdateProduct(Product prod)
        {
            return repo.UpdateProduct(prod);
        }
    }
}
