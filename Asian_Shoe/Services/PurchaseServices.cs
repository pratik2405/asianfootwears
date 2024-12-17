using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class PurchaseServices : IPurchaseServices
    {
        private readonly IPurchaseRepo repo;
        public PurchaseServices(IPurchaseRepo repo)
        {
            this.repo = repo;
        }
        public int AddPurchase(Purchase order)
        {
          return repo.AddPurchase(order);
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return repo.GetPurchases();
        }

        public IEnumerable<Purchase> GetPurchasesByUserId(int id)
        {
            return repo.GetPurchasesByUserId(id);
        }

        public int savedb()
        {
           return repo.savedb();
        }
    }
}
