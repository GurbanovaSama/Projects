using FluentValidation;

namespace FirstProject.BL.DTOs.CartItemDtos;

public class CartItemCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImagePath { get; set; }
}


//public class CartItemCreateDtoValidation : AbstractValidator<CartItemCreateDto> 
//{
//    public CartItemCreateDtoValidation()
//    {
        
//    }
//}

