using static System.Console;
using Services.Domain;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
             CityModel city = new(); 
             AreaModel area = new();

            /*area.AddArea(5,"Бла бла бла");*/
            area.UpdateArea(5, "Центральный");

            //area.DeleteArea(5);
            
            foreach (var listArea in area.GetListAll())
            {
                WriteLine(listArea.AreaName);
            };
               
            //city.CityAdd(7,"бла бла бла");

            //city.CityDelete(7);

            //city.CityUpdate(6,"Ижевск");
            
            /*
            foreach (var cityList in city.GetCityList())
            {
                WriteLine(cityList.CityName);
            }
            */
            
        }
    }
}
