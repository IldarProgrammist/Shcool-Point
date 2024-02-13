using static System.Console;
using CrmDBLab.Models;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CityModel city = new CityModel();

            //city.CityAdd(7,"бла бла бла");

            //city.CityDelete(7);

            //city.CityUpdate(6,"Ижевск");


            foreach (var cityList in city.GetCityList())
            {
                WriteLine(cityList.CityName);
            }
        }
    }
}
