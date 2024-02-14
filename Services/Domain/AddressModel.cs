using CrmDBLab.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Dynamic;

namespace Services.Domain
{
    public class AddressModel
    {
        

        public void GetListAll()
        {
           using(var db = new CrmDbContext()) 
            {
                var address = from Address in db.Addresses
                              join City in db.Cities on Address.CityId equals City.CityId
                              join Area in db.Areas on Address.AreaId equals Area.AreaId
                              join Street in db.Streets on Address.StreetId equals Street.StreetId
                              select new
                              {
                                  AddressId = Address.AddressId,
                                  Construction = Address.Construction,
                                  Street = Address.Street.StreetName,
                                  Building = Address.Building,
                                  CityName = City.CityName,
                                  AreaName = Area.AreaName,
                              };

                foreach (var item in address)
                {
                    Console.WriteLine($"ID:{item.AddressId}  " +
                        $"Улица:{item.Street} " +
                        $"Дом:  {item.Building} " +
                        $"Корпус: {item.Construction} "+
                        $"Город: {item.CityName}"
                        );
                }
            }
        }                    
    }
}
