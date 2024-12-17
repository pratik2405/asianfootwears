using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public interface IRoleRepo
    {
        public IEnumerable<Role> GetRoles();
    }
}
