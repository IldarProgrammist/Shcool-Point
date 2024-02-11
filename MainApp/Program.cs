using CrmDBLab.Models;
using static System.Console;


City city = new City
{
    CityName = null
};


//city.AddCity();

foreach (var cityList in city.GetCityList())
{
    WriteLine(cityList.CityName);
}



