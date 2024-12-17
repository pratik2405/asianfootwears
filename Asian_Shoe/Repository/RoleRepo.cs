using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class RoleRepo : IRoleRepo
    {
        private readonly ApplicationDbContext db;
        public RoleRepo(ApplicationDbContext db)
        {
            this.db = db; 

        }
        public IEnumerable<Role> GetRoles()
        {
            return db.Roles.ToList();
        }
    }
}
