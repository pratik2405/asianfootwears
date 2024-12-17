using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class CategoryRepo:ICategoryRepo
    {
        private readonly ApplicationDbContext db;
        public CategoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddCategory(Category cat)
        {
            int result = 0;
            db.Categories?.Add(cat);
            result = db.SaveChanges();
            return result;
        }
        public int DeleteCategory(int id)
        {
            int result = 0;
            var res = db.Categories?.Where(x => x.Category_id == id).FirstOrDefault();

            if (res != null)
            {
                db.Categories?.Remove(res);
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return db.Categories?.Where(x => x.Category_id == id).SingleOrDefault();
        }

        public int UpdateCategory(Category cat)
        {
            int result = 0;
            var res = db.Categories?.Where(x => x.Category_id == cat.Category_id).FirstOrDefault();
            if (res != null)
            {
                res.Category_name = cat.Category_name;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}

