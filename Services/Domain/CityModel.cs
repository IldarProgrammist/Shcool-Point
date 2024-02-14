using CrmDBLab.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Domain;

public class CityModel
{
    private CrmDbContext _db { get; set; }
    private City? City { get; set; }


    public List<City> GetCityList()
    {
        using (_db = new())
        {
            var cities = _db.Cities;
            return _db.Cities.ToList();     
        }
    }

    public void CityAdd(int id, string cityName)
    {
        using (_db = new CrmDbContext())
        {
            City = new()
            {
                CityId = id,
                CityName = cityName
            };
            _db.Cities.Add(City);
            _db.SaveChanges();
        }
    }
    public void CityUpdate(int id, string cityName) 
    {
        using (var _db = new CrmDbContext()) 
        {
            _db.Cities.Where(c => c.CityId == id)
                .ExecuteUpdate(ci => ci
                .SetProperty(c=>c.CityName, c=>cityName)
            );
        }
    }

    public void CityDelete(int id)
    {
        using (_db = new CrmDbContext())
        {
            City = _db.Cities.FirstOrDefault(c => c.CityId == id);
            _db.Cities.Remove(City);
            _db.SaveChanges();
        }
    }
}