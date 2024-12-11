using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly ApplicationDbContext db;
        public RegistrationRepo(ApplicationDbContext db)
        {
            this.db = db;  
        }
        public int AddUser(Registration user)
        {
            int result = 0;
            db.Registrations.Add(user);
            result = db.SaveChanges();
            return result;
        }

        public Registration Login(string email,string password)
        {
            return db.Registrations.Where(x => x.Email == email && x.Password == password).FirstOrDefault(); 
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            var res=db.Registrations.Where(x=>x.User_id == id).FirstOrDefault();
            if (res != null)
            {
                db.Registrations.Remove(res);
                result = db.SaveChanges();
            }  
            return result;
        }

        public IEnumerable<Registration> GetAllUser()
        {
            return db.Registrations.ToList();
        }

        public Registration GetById(int id)
        {
            return db.Registrations.Where(x => x.User_id == id).SingleOrDefault();
        }

        public int UpdateUser(Registration user)
        {
            int result = 0;
            var res=db.Registrations.Where(x=>x.User_id==user.User_id).FirstOrDefault();
            if(res!=null)
            {
                res.User_id = user.User_id;
                res.First_name = user.First_name;
                res.Last_name = user.Last_name;
                res.PhoneNumber = user.PhoneNumber;
                res.Address = user.Address;
                res.Email = user.Email;
                res.Password = user.Password;
                res.role_id = user.role_id;

                result = db.SaveChanges();
            }
            return result;

        }
    }
}
