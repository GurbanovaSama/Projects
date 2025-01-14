using AutoMapper;
using FirstProject.BL.DTOs.CartItemDtos;
using FirstProject.DAL.Models;

namespace FirstProject.BL.Profiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItemCreateDto, CartItem>().ReverseMap(); 
        }
    }
}
