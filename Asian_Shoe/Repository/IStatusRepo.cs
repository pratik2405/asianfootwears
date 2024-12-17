using Asian_Shoe.Models;

namespace Asian_Shoe.Repository
{
    public interface IStatusRepo
    {
        public IEnumerable<Status> GetStatuses();
    }
}
