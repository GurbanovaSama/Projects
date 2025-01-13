using FirstProject.BL.Services.Abstractions;
using FirstProject.DAL.Contexts;
using FirstProject.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.BL.Services.Implementations;

public class CartItemService : ICartitemService
{
    private readonly AppDbContext _context;

    public CartItemService(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<CartItem> Table => _context.Set<CartItem>();   


    public async Task CreateCartItemAsync(CartItem cartItem)
    {
        await Table.AddAsync(cartItem);
        int rows = await _context.SaveChangesAsync();   
        if(rows!=1)
        {
            throw new Exception("Cart item cannot be added");
        }
    }


    public async Task<List<CartItem>> GetAllCartItemAsync()
    {
        List<CartItem> cartItem = await Table.ToListAsync();  
        return cartItem;
    }


    public async Task<CartItem> GetCartItemByIdAsync(int id)
    {
        CartItem? cartItem = await Table.FindAsync(id);
        if(cartItem is null)
        {
            throw new Exception($"Cart item is not found this id{id}");
        }
        return cartItem;
    }


    public async Task HardDeleteCartItemAsync(int id)
    {
        CartItem? cartItem = await Table.FindAsync(id);
        if (cartItem is null)
        {
            throw new Exception($"Cart item is not found this id{id}");
        }
        Table.Remove(cartItem); 
    }


    public async Task SoftDeleteCartItemAsync(int id)
    {
        CartItem? cartItem = await table.SingleOrDefaultAsync(s => s.Id == id && !s.IsDeleted);  
        if(cartItem is null)
        {
            throw new Exception($"Cart item is not found this id{id}");
        }
        cartItem.IsDeleted = true;
        cartItem.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();  
    }


    public async Task UpdateCartItemAsync(int id, CartItem cartItem)
    {
        if (cartItem.Id == id)
        {
            throw new Exception("Ids are not same");
        }
        CartItem? baseCartItem = await table.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id && !s.IsDeleted);   
        if (baseCartItem is null)
        {
            throw new Exception($"Cart item is not found this id{id}");
        }

        baseCartItem.UpdatedAt = DateTime.Now;
        cartItem.CreatedAt = baseCartItem.CreatedAt;    
        table.Update(cartItem); 
        await _context.SaveChangesAsync();  
    }
}
