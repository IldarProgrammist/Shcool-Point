using CrmDBLab.Models;
using Microsoft.EntityFrameworkCore;
namespace Services.Domain
{
    public class AddressModel
    {
        private CrmDbContext _db;

        public List<Address> GetAddress() 
        {
            using(_db = new CrmDbContext())
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
