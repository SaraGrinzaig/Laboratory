using AutoMapper;
using DAL.Models;
using Service.DTOs;

namespace Service.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<StatusType, StatusTypeDto>().ReverseMap();
        }
    }
}
