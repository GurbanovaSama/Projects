using FirstProject.DAL.Models.Base;

namespace FirstProject.DAL.Models;

public class CartItem : BaseAuiditableEntity
{
    public string Name { get; set; }    
    public string Description { get; set; } 
    public string ImagePath { get; set; }       
     
}
