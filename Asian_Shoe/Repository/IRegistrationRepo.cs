using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public interface IRegistrationRepo
    {
        IEnumerable<Registration> GetAllUser();

        public Registration GetById(int id);

        public int AddUser(Registration user);

        public Registration Login(string email, string password);

        public int DeleteUser(int id);

        public int UpdateUser(Registration user);
    }
}
