using Model;
using Model.DTO;
using Model.DTO.USERDTO;
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
        public Response DeleteUser(DeleteUserDTO deleteUserDTO);
        public Response FindUserById(string id);
        public Response ChangeStatusUserToInActive(IdUserUpdateStatus idUserUpdate);
        public Response FindUserActive();
        public Response FindUsersInactive();
        public Response ChangeStatusUserToActive(IdUserUpdateStatus idUserUpdate);
    }
}
