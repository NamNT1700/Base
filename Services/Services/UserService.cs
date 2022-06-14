using AutoMapper;
using Common;
using Loggger;
using Microsoft.Extensions.Configuration;
using Model;
using Model.DTO;
using Model.DTO.USERDTO;
using Repository;
using Repository.IRepository;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class UserService : IUserService
    {
        // private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private Context _context;
        private IRepositoryWrapper _repositoryWrapper;
        private IloggerManager _logger;
        private IConfiguration _configuration;

        public UserService(IMapper mapper, IloggerManager logger, IConfiguration configuration,
            IRepositoryWrapper repositoryWrapper)
        {
            //_repository = repository;
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
            _repositoryWrapper = repositoryWrapper;

        }
        public Response Register(RegisterUserDTO reUser)
        {
            Response respones = new Response();
            try
            {

                string description = _repositoryWrapper.User.CheckUserInfo(reUser.username, reUser.email);
                if (description != null)
                {
                    _logger.LogError(description);
                    respones.status = "Error";
                    respones.data = description;
                    return respones;
                }
                reUser.password = CodingPassword.EncodingUTF8(reUser.password);
                User newUser = _mapper.Map<User>(reUser);
                _repositoryWrapper.User.AddNew(newUser);
                _repositoryWrapper.Save();
                respones.status = "Success";
                respones.data = newUser;
                return respones;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return respones;
            }

        }
        public Response GetAllUsers(int page)
        {
            List<User> allUsers = _repositoryWrapper.User.FindAllData();
            IEnumerable<UserDTO> listUser = _mapper.Map<IEnumerable<UserDTO>>(allUsers);
            Response response = new Response();

            List<User> users = new List<User>();
            int index = (page - 1) * 10;
            if (index > allUsers.Count())
            {
                response.status = "Success";
                response.data = "no user yet";
                return response;
            }
            if (index + 10 < allUsers.Count())
                users = allUsers.GetRange(index, 10);
            else users = allUsers.GetRange(index, allUsers.Count - index);
            response.status = "Success";
            response.data = users;
            return response;
        }

        public Response Login(LoginDTO user)
        {
            Response respones = new Response();
            string encodePass = CodingPassword.EncodingUTF8(user.password);
            string description = _repositoryWrapper.User.CheckUserLogin(user.username, encodePass);
            if (description == null)
            {
                User loginUser = _repositoryWrapper.User.FindByUsername(user.username);
                TokenGenarate accessToken = new TokenGenarate(_configuration);
                string token = accessToken.GenerateAccessToken(loginUser);
                respones.status = "Success";
                respones.data = token;
                return respones;
            }
            respones.status = "Error";
            respones.data = description;
            return respones;
        }

        public Response DeleteUser(DeleteUserDTO deleteUserDTO)
        {
            Response respones = new Response();
            foreach (string id in deleteUserDTO.ids)
            {
                User existUser = _repositoryWrapper.User.FindById(id);
                if (existUser != null)
                {
                    _repositoryWrapper.User.Delete(existUser);
                    _repositoryWrapper.Save();
                }
            }
            respones.status = "Success";
            respones.data = "Delete successfull";
            return respones;
        }

        public Response FindUserById(string id)
        {
            Response respones = new Response();
            User existUser = _repositoryWrapper.User.FindById(id);
            if (existUser == null)
            {
                respones.status = "Error";
                respones.data = "User not exist";
                return respones;
            }
            respones.status = "Success";
            respones.data = existUser;
            return respones;
        }

        public Response ChangeStatusUserToInActive(IdUserUpdateStatus idUserUpdate)
        {
            Response respones = new Response();
            foreach (string id in idUserUpdate.ids)
            {
                User existUser = _repositoryWrapper.User.FindById(id);
                
                if (existUser.isActive == "A")
                {
                    respones.status = "Error";
                    respones.data = $"User {existUser.id} is already Active";
                    return respones;
                }
                existUser.isActive = "I";
                //idUserUpdate.updateStatusUserDTO.isActive = "I";
                //_mapper.Map(idUserUpdate.updateStatusUserDTO, existUser);
                _repositoryWrapper.User.Update(existUser);
            }
            _repositoryWrapper.Save();
            respones.status = "Success";
            respones.data = $"Now status of users is Inactive";
            return respones;
        }
        public Response ChangeStatusUserToActive(IdUserUpdateStatus idUserUpdate)
        {
            Response respones = new Response();
            foreach (string id in idUserUpdate.ids)
            {
                User existUser = _repositoryWrapper.User.FindById(id);
                if (existUser.isActive == "I")
                {
                    respones.status = "Error";
                    respones.data = $"User {existUser.id} is already Inactive";
                    return respones;
                }    
                existUser.isActive = "A";
                //idUserUpdate.updateStatusUserDTO.isActive = "A";
                //_mapper.Map(idUserUpdate.updateStatusUserDTO, existUser);
                _repositoryWrapper.User.Update(existUser);
            }
            _repositoryWrapper.Save();
            respones.status = "Success";
            respones.data = $"Now status of users is Active";
            return respones;
        }

        public Response FindUserActive()
        {
            Response respones = new Response();
            List<User> users = new List<User>();
            users = _repositoryWrapper.User.FindUsersActive();
            if (users.Count == 0)
            {
                respones.status = "Success";
                respones.data = "No user is Active";
                return respones;
            }
            respones.status = "Success";
            respones.data = users;
            return respones;
        }

        public Response FindUsersInactive()
        {
            Response respones = new Response();
            List<User> users = new List<User>();
            users = _repositoryWrapper.User.FindUsersInactive();
            if(users.Count==0)
            {
                respones.status = "Success";
                respones.data = "No user is InActive";
                return respones;
            }
            respones.status = "Success";
            respones.data = users;
            return respones;
        }
    }
}
