using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly IRegistrationRepo repo;
        public RegistrationServices(IRegistrationRepo repo)
        {
            this.repo = repo;
        }
        public int AddUser(Registration user)
        {
           return repo.AddUser(user);
        }

        public int DeleteUser(int id)
        {
           return repo.DeleteUser(id);
        }

        public IEnumerable<Registration> GetAllUser()
        {
            return repo.GetAllUser();
        }

        public Registration GetById(int id)
        {
           return repo.GetById(id);
        }

        public Registration Login(string email,string password)
        {
            return repo.Login(email,password);
        }

        public int UpdateUser(Registration user)
        {
            return repo.UpdateUser(user);
        }
    }
}
