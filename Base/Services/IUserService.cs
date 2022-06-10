using Base.Datas.DTO;
using Base.Datas.Respones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Services
{
    public interface IUserService
    {
        public Response Register(RegisterUserDTO reUser);
        public Response GetAllUsers();
    }
}
