using Microsoft.EntityFrameworkCore;
using ModelDomain.Model;
namespace Services.Domain;

public class CityModel
{
    private SchoolPointContext _db { get; set; }
    private City? City { get; set; }


    public List<City> GetCityList()
    {
        using (_db = new())
        {
            return _db.Cities.ToList();
        }
    }

    public void CityAdd(string cityName)
    {
        using (_db = new SchoolPointContext())
        {       
            City = new()
            {
                CityName = cityName
            };
            _db.Cities.Add(City);
            _db.SaveChanges();
        }
    }
    public void CityUpdate(int id, string cityName)
    {
        using (_db = new())
        {
         var city =_db.Cities
                 .Where(c => c.CityId == id)
                 .FirstOrDefault();
        
            city.CityName = cityName;
            _db.SaveChanges();
        }
    }

    public void CityDelete(int id)
    {
        using (_db = new SchoolPointContext())
        {
            City = _db.Cities.FirstOrDefault(c => c.CityId == id);
            _db.Cities.Remove(City);
            _db.SaveChanges();
        }
    }
}