using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiBar.Dtos;
using WebApiBar.Models;

namespace WebApiBar.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //Post
            CreateMap<CustomerPostDto, Customer>(); // Origen - destino
            //Put
            CreateMap<CustomerPutDto, Customer>();
            //Get
            CreateMap<CustomerGetDto, Customer>();        
        }
    }
}