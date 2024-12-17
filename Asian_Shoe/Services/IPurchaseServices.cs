using Asian_Shoe.Models;

namespace Asian_Shoe.Services
{
    public interface IPurchaseServices
    {
        public int AddPurchase(Purchase order);
        public IEnumerable<Purchase> GetPurchases();

        public IEnumerable<Purchase> GetPurchasesByUserId(int id);

        public int savedb();
        
    }
}
