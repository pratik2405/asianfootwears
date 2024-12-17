using Asian_Shoe.Models;

namespace Asian_Shoe.Services
{
    public interface IStatusServices
    {
        public IEnumerable<Status> GetStatuses();
    }
}
