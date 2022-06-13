using AutoMapper;
using Model;
using Model.DTO;
using Model.DTO.USERDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<RegisterUserDTO, User>().ForMember(i => i.id,newId => newId.MapFrom(newID=>newID.id));
            CreateMap<UpdateStatusUserDTO, User>();
        }
    }
}
