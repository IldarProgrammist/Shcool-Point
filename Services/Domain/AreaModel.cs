using CrmDBLab.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain
{
    public class AreaModel
    {
        private CrmDbContext? _db;
        private Area? Area;

        public List<Area> GetListAll()
        {
            using (_db = new CrmDbContext())
            {
               return _db.Areas.ToList();
            }
        } 
        
        public void AddArea(int id, string areaName)
        {
            using (_db = new CrmDbContext()) 
            { 
                Area area = new Area() 
                { 
                    AreaId = id,
                    AreaName = areaName
                };
                _db.Areas.Add(area);    
               _db.SaveChanges ();
            }
        }

        public void UpdateArea(int id, string areaName)
        {
            using (var _db = new CrmDbContext())
            {
                _db.Areas.Where(area => area.AreaId == id)
                    .ExecuteUpdate(areaUpdate => areaUpdate
                    .SetProperty( area => area.AreaName, area=> areaName)
                );
            }
        }
    
        public void DeleteArea(int id) 
        { 
            using(_db = new CrmDbContext())
            {
                 Area = _db.Areas.FirstOrDefault(a=>a.AreaId == id);
                _db.Remove(Area);
                _db.SaveChanges ();
            }
        }
    }
}
