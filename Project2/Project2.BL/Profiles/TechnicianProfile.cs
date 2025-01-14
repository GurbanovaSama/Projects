using AutoMapper;
using Project2.BL.DTOs;
using Project2.DAL.Models;

namespace Project2.BL.Profiles;

public class TechnicianProfile : Profile
{
    public TechnicianProfile()
    {
        CreateMap<Technician, TechnicianPostDto>().ReverseMap();
        CreateMap<Technician, TechnicianGetDto>().ReverseMap(); 
        CreateMap<Technician, TechnicianUpdateDto>().ReverseMap();
    }
}
