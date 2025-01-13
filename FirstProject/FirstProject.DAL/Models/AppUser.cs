using Microsoft.AspNetCore.Identity;

namespace FirstProject.DAL.Models;

public class AppUser : IdentityUser
{
    public string FirstName {  get; set; }   
    public string LastName { get; set; }    
}
