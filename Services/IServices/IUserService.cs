using Model;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IUserService
    {
        public Response Register(RegisterUserDTO reUser);
        public Response GetAllUsers(int page);
        public Response Login(LoginDTO user);
    }
}
