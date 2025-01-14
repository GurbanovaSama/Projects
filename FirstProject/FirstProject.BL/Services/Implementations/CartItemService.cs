using AutoMapper;
using FirstProject.BL.DTOs.CartItemDtos;
using FirstProject.BL.Services.Abstractions;
using FirstProject.DAL.Models;
using FirstProject.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net.WebSockets;

namespace FirstProject.BL.Services.Implementations;


public class CartItemService : ICartItemService
{
    private readonly IReadRepository<CartItem> _readRepo;
    private readonly IWriteRepository<CartItem> _writeRepo;
    private readonly IMapper _mapper;

    public CartItemService(IReadRepository<CartItem> readRepo, IWriteRepository<CartItem> writeRepo, IMapper mapper)
    {
        _readRepo = readRepo;
        _writeRepo = writeRepo;
        _mapper = mapper;
    }

    public async Task<CartItem> CreateAsync(CartItemCreateDto entityDto)
    {
        CartItem createdCart = _mapper.Map<CartItem>(entityDto);    
        createdCart.CreatedAt = DateTime.UtcNow.AddHours(4); 
        var createdEntity = await _writeRepo.CreateAsync(createdCart);
        await _writeRepo.SaveChangeAsync();
        return createdEntity;
    }


    public async Task<ICollection<CartItem>> GetAllAsync()
    {
        return await _readRepo.GetAllAsync();   
    }

    public async Task<CartItem> GetByIdAsync(int id)
    {
        if(!await _readRepo.IsExistsAsync(id))
        {
            throw new Exception("Something went wrong");
        }
        return await _readRepo.GetByIdAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var cartEntity = await _readRepo.GetByIdAsync(id);
        _writeRepo.SoftDelete(cartEntity);
        await _writeRepo.SaveChangeAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, CartItemCreateDto entityDto)
    {
        var cartEntity = await _readRepo.GetByIdAsync(id);
        CartItem updatedCart = _mapper.Map<CartItem>(entityDto);
        updatedCart.UpdatedAt = DateTime.UtcNow.AddHours(4);        
        updatedCart.Id = id;    
        _writeRepo.Update(updatedCart);
        await _writeRepo.SaveChangeAsync();
        return true;
    }
    //public async Task<bool> EditAsync(int id, CartItemEditDto editDto)
    //{
    //    var cartEntity = await _readRepo.GetByIdAsync(id);
    //    _mapper.Map(CartItemEditDto, editDto);
    //    cartEntity.UpdatedAt = DateTime.UtcNow.AddHours(4);
    //    _writeRepo.Update(cartEntity);
    //    await _writeRepo.SaveChangeAsync();
    //    return true;
    //}
}
