using Asian_Shoe.Models;
using Asian_Shoe.Repository;

namespace Asian_Shoe.Services
{
    public class StatuseServices : IStatusServices
    {
        private readonly IStatusRepo repo;
        public StatuseServices(IStatusRepo repo)
        {
            this.repo = repo; 
        }
        public IEnumerable<Status> GetStatuses()
        {
            return repo.GetStatuses();
        }
    }
}
