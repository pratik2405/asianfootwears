using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class PurchaseDetailsServices : IPurchaseDetailsServices
    {
        private readonly IPurchaseDetailsRepo repo;
        public PurchaseDetailsServices(IPurchaseDetailsRepo repo)
        {
            this.repo = repo;
        }
        public int Add(PurchaseDetails details)
        {
            return repo.Add(details);
        }

        public int Delete(int id)
        {
            return repo.Delete(id);
        }

        public IEnumerable<PurchaseDetails> GetAll()
        {
            return repo.GetAll();
        }

        public PurchaseDetails GetByPurchaseId(int pid)
        {
           return repo.GetByPurchaseId(pid);
        }

        public IEnumerable<PurchaseDetails> GetByUserId(int userId)
        {
            return repo.GetByUserId(userId);
        }

        public int SaveDb()
        {
            return repo.SaveDb();
        }

        public int Update(PurchaseDetails details)
        {
            return repo.Update(details);
        }

        
    }
}
