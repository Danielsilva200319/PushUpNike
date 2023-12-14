using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Api.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<County, CountryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Phone, PhoneDto>().ReverseMap();
            CreateMap<Postalcode, PostalCodeDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Shipment, ShipmentDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Typeclient, TypeClientDto>().ReverseMap();
            CreateMap<Typeorder, TypeOrderDto>().ReverseMap();
            CreateMap<Typepayment, TypePaymentDto>().ReverseMap();
            CreateMap<Typeproduct, TypeProductDto>().ReverseMap();
            CreateMap<Typeshipment, TypeShipmentDto>().ReverseMap();
        }
    }
}