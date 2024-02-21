using Microsoft.EntityFrameworkCore;
using ModelDomain.Model;

namespace Services.Domain
{
    public class AreaModel
    {
        private SchoolPointContext _db;
        private Area? Area;

        public List<Area> GetListAll()
        {
            using (_db = new())
            {
               return _db.Areas.ToList();
            }
        } 
        
        public void AddArea(string areaName)
        {
            using (_db = new()) 
            { 
                Area area = new Area() 
                { 
                    AreaName = areaName
                };
                _db.Areas.Add(area);    
               _db.SaveChanges ();
            }
        }

        public void UpdateArea(int id, string areaName)
        {
            using (_db = new())
            {
                _db.Areas.ExecuteUpdate(
                        c=>c.SetProperty(c=>c.AreaName, areaName)
                    );
                _db.SaveChanges();
            }  
        }
    
        public void DeleteArea(int id) 
        { 
            using(_db = new())
            {
                 Area = _db.Areas.FirstOrDefault(a=>a.AreaId == id);
                _db.Remove(Area);
                _db.SaveChanges ();
            }
        }
    }
}
