using AutoMapper;
using Base.Datas.DTO;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Services
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<RegisterUserDTO, User>();
        }
    }
}
