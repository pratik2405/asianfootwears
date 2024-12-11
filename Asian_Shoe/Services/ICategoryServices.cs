using Asian_Shoe.Models;

namespace Asian_Shoe.Services
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCategories();
        Category GetCategoryById(int id);
        int AddCategory(Category cat);
        int UpdateCategory(Category cat);
        int DeleteCategory(int id);
    }
}
