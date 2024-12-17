using Asian_Shoe.Models;

namespace Asian_Shoe.Services
{
    public interface IPurchaseDetailsServices
    {
        public IEnumerable<PurchaseDetails> GetAll();

        public int Add(PurchaseDetails details);

        public int Update(PurchaseDetails details);

        public int Delete(int id);

        public IEnumerable<PurchaseDetails> GetByUserId(int userId);
        public PurchaseDetails GetByPurchaseId(int pid);
        public int SaveDb();
    }
}
