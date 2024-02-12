namespace CrmDBLab.Models;

public  class City
{
    private CrmDbContext db;
    public City() { }
    public City(int cityId, string? cityName)
    {
        CityId = cityId;
        CityName = cityName;
    }
    
    public City(string cityName)
    {
        
    }

    public int CityId { get; set; }
    public required string? CityName { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    
    public List<City> GetCityList()
    {
        var db = new CrmDbContext();
        var cities = db.Cities;
        return db.Cities.ToList();
    }
    public void AddCity()
    {
        using (var db = new CrmDbContext())
        {
            City city = new City(CityId, CityName)
            {
                CityName = null
            };
            db.Cities.Add(city);
            db.SaveChanges();
        }
    }
}
