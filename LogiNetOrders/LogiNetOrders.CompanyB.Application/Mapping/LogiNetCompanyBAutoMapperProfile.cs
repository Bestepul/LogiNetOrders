using AutoMapper;
using AutoMapper.Internal.Mappers;
using LogiNetOrders.CompanyB.Application.Commands.OrderCommands;
using LogiNetOrders.CompanyB.Application.Commands.PersonCommands;
using LogiNetOrders.CompanyB.Application.Commands.ProductCommands;
using LogiNetOrders.CompanyB.Application.Responses;
using LogiNetOrders.CompanyB.Domain.LogiNetOrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiNetOrders.CompanyB.Application.Mapping
{
    public class LogiNetCompanyBAutoMapperProfile : Profile
    {
        public LogiNetCompanyBAutoMapperProfile()
        {
            CreateMap<Person, CreatePersonCommand>().ReverseMap();
            CreateMap<Products, CreateProductCommand>().ReverseMap();
            CreateMap<CreateOrderCommand, Orders>()
            .ForMember(dest => dest.OrderProducts, opt => opt.Ignore());
            CreateMap<OrderProductsCommand, OrderProducts>();

            CreateMap<Orders, GetOrdersResponse>()
           .ForMember(dest => dest.Consignee, opt => opt.MapFrom(src => src.Consignee))
           .ForMember(dest => dest.OrderProducts, opt => opt.MapFrom(src => src.OrderProducts));

            CreateMap<Person, GetPersonResponse>();

            CreateMap<OrderProducts, GetOrderProductsResponse>()
           .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product));

            CreateMap<Products, GetProductResponse>();


        }

    }
}
