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
                    respones.status = "400";
                    respones.success = false;
                    respones.message=description;
                    return respones;
                }
                reUser.password = CodingPassword.EncodingUTF8(reUser.password);
                User newUser = _mapper.Map<User>(reUser);
                _repositoryWrapper.User.AddNew(newUser);
                _repositoryWrapper.Save();
                respones.status = "200";
                respones.success = true;
                respones.item = newUser;
                return respones;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
                return respones;
            }

        }
        public Response GetAllUsers(BaseRequest<User> baseRequest)
        {
            List<User> allUsers = _repositoryWrapper.User.FindAllData(baseRequest.keyworks);
            IEnumerable<UserDTO> listUser = _mapper.Map<IEnumerable<UserDTO>>(allUsers);
            Response response = new Response();
            
            List<User> users = new List<User>();
            int firstIndex = (baseRequest.pageNum - 1) * baseRequest.pageSize;
            if (firstIndex >= allUsers.Count())
            {
                response.status = "400";
                response.success = false;
                response.message="no user yet";
                return response;
            }
            if (firstIndex + baseRequest.pageSize < allUsers.Count())
                users = allUsers.GetRange(firstIndex, baseRequest.pageSize);
            else users = allUsers.GetRange(firstIndex, allUsers.Count - firstIndex);
            response.status = "Success";
            response.success = true;
            response.item = users;
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
                respones.status = "200";
                respones.success = true;
                respones.item = token;
                return respones;
            }
            respones.status = "200";
            respones.success = false;
            respones.message=description;
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
            respones.status = "200";
            respones.success = true;
            respones.message="Delete successfull";
            return respones;
        }

        public Response FindUserById(string id)
        {
            Response respones = new Response();
            User existUser = _repositoryWrapper.User.FindById(id);
            if (existUser == null)
            {
                respones.status = "400";
                respones.success = false;
                respones.message="User not exist";
                return respones;
            }
            respones.status = "200";
            respones.success = true;
            respones.item = existUser;
            return respones;
        }

        public Response ChangeStatusUser(IdUserUpdateStatus idUserUpdate)
        {
            Response respones = new Response();
                User existUser = _repositoryWrapper.User.FindById(idUserUpdate.id);
                if (existUser.isActive == "A")
                     existUser.isActive = "I";
                if (existUser.isActive == "I")
                    existUser.isActive = "A";
                _repositoryWrapper.User.Update(existUser);

            _repositoryWrapper.Save();
            respones.status = "200";
            respones.success = true;
            respones.message =$"Now status of users is Inactive";
            return respones;
        }
       

       

        
    }
}
