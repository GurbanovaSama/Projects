using AutoMapper;
using FirstProject.BL.Services.Abstractions;
using FirstProject.BL.Services.Implementations;
using FirstProject.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CartItemController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly IMapper _mapper;

        public CartItemController(ICartItemService cartItemService, IMapper mapper)
        {
            _cartItemService = cartItemService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<CartItem> cartItems = await _cartItemService.GetAllAsync();
            return View(cartItems);
        }
    }
}
