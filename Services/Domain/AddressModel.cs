using Microsoft.EntityFrameworkCore;
using ModelDomain.Model;
namespace Services.Domain
{
    public class AddressModel
    {
        private SchoolPointContext _db;

        public List<Address> GetAddress() 
        {
            using(_db = new SchoolPointContext())
            {
                var addresess = _db.Addresses
                    .Include(a => a.City)
                    .Include(a=>a.Area)
                    .Include(a=>a.Street)
                    .ToList();
                return addresess;
            }           
        }
    }
}
