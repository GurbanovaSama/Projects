using Project2.DAL.Models.Base;

namespace Project2.DAL.Models;

public class Technician :BaseAuiditableEntity
{
    public string Name { get; set; }        
    public string Position { get; set; }
    public string ImagePath { get; set; }   
    public int ServiceId { get; set; }  
    public Service? Service { get; set; }    
}
