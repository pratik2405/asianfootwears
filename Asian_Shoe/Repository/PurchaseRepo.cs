using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class PurchaseRepo:IPurchaseRepo
    {
        private readonly ApplicationDbContext db;
        public PurchaseRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddPurchase(Purchase order)
        {
            int result = 0;
            db.Purchases.Add(order);
            result = db.SaveChanges();
            return result;
        }

        public IEnumerable<Purchase> GetPurchases()
        {
            return db.Purchases.ToList();
        }

        public IEnumerable<Purchase> GetPurchasesByUserId(int id)
        {
            return db.Purchases.Where(x=>x.User_id == id).ToList();
        }

        public int savedb()
        {
            return db.SaveChanges();
        }
    }
}
