using Asian_Shoe.Data;
using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public class StatusRepo : IStatusRepo
    {
        private readonly ApplicationDbContext db;
        public StatusRepo(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Status> GetStatuses()
        {
            return db.Statuses.ToList(); 
        }
    }
}
