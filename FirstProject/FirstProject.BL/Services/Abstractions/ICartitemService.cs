using FirstProject.DAL.Models;

namespace FirstProject.BL.Services.Abstractions;

public interface ICartitemService
{
    Task<List<CartItem>> GetAllCartItemAsync();   
    Task<CartItem>  GetCartItemByIdAsync(int id);  
    Task CreateCartItemAsync(CartItem cartItem);
    Task SoftDeleteCartItemAsync(int id);
    Task HardDeleteCartItemAsync(int id);
    Task UpdateCartItemAsync(int id, CartItem cartItem);
    
}
