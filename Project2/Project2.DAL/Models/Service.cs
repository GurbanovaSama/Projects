using Project2.DAL.Models.Base;

namespace Project2.DAL.Models;

public class Service : BaseAuiditableEntity
{
    public string Name { get; set; }    
    public string Description { get; set; }
    public ICollection<Technician>? Technicians { get; set; }
}
