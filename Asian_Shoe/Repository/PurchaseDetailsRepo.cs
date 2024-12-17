using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class PurchaseDetailsRepo : IPurchaseDetailsRepo
    {
        private readonly ApplicationDbContext db;
        public PurchaseDetailsRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int Add(PurchaseDetails details)
        {
            int result = 0;
            db.PurchasesDetails.Add(details);
            result=db.SaveChanges();
            return result;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurchaseDetails> GetAll()
        {
             return db.PurchasesDetails.ToList();
        }

        public PurchaseDetails GetByPurchaseId(int pid)
        {
            return db.PurchasesDetails.Where(x => x.Purchase_Details_id == pid).FirstOrDefault();
        }

        public IEnumerable<PurchaseDetails> GetByUserId(int userId)
        {
          
            var res = (from pd in db.PurchasesDetails
                      join p in db.Products on pd.product_id equals p.Product_id
                      join pur in db.Purchases on pd.purchase_id equals pur.Purchase_id
                      where pd.user_id == userId
                      select new PurchaseDetails
                      {
                          product_id = pd.product_id,
                          Image_url=p.Image_Url,
                          status_id = pd.status_id,
                          user_id = pd.user_id,
                          Quantity=pur.Quantity,
                          status_name = pd.status_name,
                          delivery_date = pd.delivery_date,
                         order_Date=pur.Date_of_order,
                          TotalAmt=pd.TotalAmt,
                          purchase_id = pd.purchase_id,
                          Product_name=p.Product_name
                      }).ToList();
            return res;
        }

        public int SaveDb()
        {
            return db.SaveChanges();    
        }

        public int Update(PurchaseDetails details)
        {
            int result = 0;
            var res= db.PurchasesDetails.Where(x=>x.Purchase_Details_id==details.Purchase_Details_id).SingleOrDefault();
            if (res!=null)
            {
                res.purchase_id = details.purchase_id;
                res.product_id = details.product_id;
                res.user_id = details.user_id;
                res.TotalAmt= details.TotalAmt;
                res.status_id = details.status_id;

                result = db.SaveChanges();
            }
            return result;
        }
    }
}
