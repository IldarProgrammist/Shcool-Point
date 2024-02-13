using CrmDBLab.Models;
using static System.Console;

CityModel cityModel = new();


CityModel city = new CityModel();

//city.CityAdd(7,"бла бла бла");

city.CityDelete(7);

//city.CityUpdate(6,"Ижевск");


foreach (var cityList in city.GetCityList())
{
    WriteLine(cityList.CityName);
}



