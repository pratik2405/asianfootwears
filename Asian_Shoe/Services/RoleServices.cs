using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepo repo;
        public RoleServices(IRoleRepo repo)
        {
            this.repo = repo; 
        }
        public IEnumerable<Role> GetRoles()
        {
            return repo.GetRoles();
        }
    }
}
