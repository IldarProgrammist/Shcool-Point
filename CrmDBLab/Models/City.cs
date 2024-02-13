namespace CrmDBLab.Models;

public  class City
{
    public int CityId { get; set; }
    public required string? CityName { get; set; }
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    
}
