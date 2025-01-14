using FirstProject.BL.DTOs.CartItemDtos;
using FirstProject.DAL.Models;

namespace FirstProject.BL.Services.Abstractions;

public interface ICartItemService
{
    Task<ICollection<CartItem>> GetAllAsync();
    Task<CartItem> CreateAsync(CartItemCreateDto entityDto);
    Task<CartItem> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, CartItemCreateDto entityDto);
    //Task<bool> EditAsync(int id, CartItemEditDto editDto);
}
