using AutoMapper;
using MVCPractice.Dtos;
using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPractice.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Person, PersonDto>();
        }
    }
}