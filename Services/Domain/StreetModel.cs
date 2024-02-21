using ModelDomain.Model;

namespace Services.Domain
{
    public class StreetModel
    {
        private SchoolPointContext _db { get; set; }
        private Street? Street { get; set; }


        public List<Street> GetStreetList()
        {
            using (_db = new())
            {
                return _db.Streets.ToList();
            }
        }

        public void StreetAdd(string streetName)
        {
            using (_db = new SchoolPointContext())
            {
                Street = new()
                {
                    StreetName = streetName
                };
                _db.Streets.Add(Street);
                _db.SaveChanges();
            }
        }
        public void StreetUpdate(int id, string streetName)
        {
            using (_db = new())
            {
                var street = _db.Streets
                        .Where(c => c.StreetId == id)
                        .FirstOrDefault();

                street.StreetName = streetName; 
                _db.SaveChanges();
            }
        }

        public void StreetDelete(int id)
        {
            using (_db = new SchoolPointContext())
            {
                Street = _db.Streets.FirstOrDefault(c => c.StreetId == id);
                _db.Streets.Remove(Street);
                _db.SaveChanges();
            }
        }
    }
}
