using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepo repo;
        public CategoryServices(ICategoryRepo repo)
        {
            this.repo = repo;
        }
        public int AddCategory(Category cat)
        {
            return repo.AddCategory(cat);
        }

        public int DeleteCategory(int id)
        {
            return repo.DeleteCategory(id);
        }

        public IEnumerable<Category> GetCategories()
        {
            return repo.GetCategories();
        }

        public Category GetCategoryById(int id)
        {
            return repo.GetCategoryById(id);
        }

        public int UpdateCategory(Category cat)
        {
            throw new NotImplementedException();
        }
    }
}
