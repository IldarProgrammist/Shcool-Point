using static System.Console;
namespace CrmDBLab.Models;

public class CityModel
{
    private CrmDbContext db;
    public void PrintCityList()
    {
        foreach (var city in db.Cities)
        {
            WriteLine(city.CityName);
        }
    }
    
    public void AddCity()
    {
       
    }
}