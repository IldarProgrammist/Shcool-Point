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
                AddressModel addressModel = new();
                CityModel cityModel = new();


            //cityModel.CityAdd("бла бла бла");
            //cityModel.CityUpdate(6,"Новосибирск");
            //cityModel.CityDelete(4);

             AreaModel areaModel = new();
            //areaModel.UpdateArea(1,"Арбат");
            //areaModel.AddArea("Бла бла бла");
            //areaModel.DeleteArea(2);

           /* foreach (var item in cityModel.GetCityList())
            {
                WriteLine($"Город:{item.CityName}");
            }*/

           /* foreach (var item in areaModel.GetListAll())
            {
                WriteLine($"Район:{item.AreaName}");
            }*/
        
        
            StreetModel streetModel = new();

            foreach (var item in streetModel.GetStreetList())
            {
                WriteLine(item.StreetName);
            }

            //streetModel.StreetAdd("Ленина");
            //streetModel.StreetUpdate(1, "Невский проспект");
            //streetModel.StreetDelete(4);

        }
    }
}
