using AspNetCoreGeneratedDocument;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project2.BL.Services.Abstractions;
using Project2.DAL.Models;

namespace Project2.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TechnicianController : Controller
    {
        private readonly ITechnicianService _technicianService;
        private readonly IMapper _mapper;


        public TechnicianController(ITechnicianService technicianService, IMapper mapper)
        {
            _technicianService = technicianService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Technician> technicians = await _technicianService.GetAllAsync();
            return View(technicians);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Technician technician)
        {
            _technicianService.CreateAsync(technician);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Info(int id)
        {
            Technician technician = await _technicianService.GetByIdAsync(id);
            return View(technician);
        }

       [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Technician technician =await _technicianService.GetByIdAsync(id);
            return View(technician);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, Technician technician)
        {
            if(!ModelState.IsValid)
            {
                return View(technician);
            }

            await _technicianService.UpdateAsync(id, technician);
            return RedirectToAction(nameof(Index)); 
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Technician technician = await _technicianService.GetByIdAsync(id);
            return View(technician);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _technicianService.SoftDeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}

