using AutoMapper;
using Base.Common;
using Base.Datas.DTO;
using Base.Datas.IRepository;
using Base.Datas.Repository;
using Base.Datas.Respones;
using Base.Log;
using Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Base.Services
{
    public class UserServices: IUserService
    {
       // private IRepositoryWrapper _repository;
        private IMapper _mapper;
        public Context _context;
        private IUserRepository _userRepository;
        private IloggerManager _logger;
        private IConfiguration _configuration;

        public UserServices(IMapper mapper, IUserRepository userRepository, IloggerManager logger, IConfiguration configuration)
        {
            //_repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
            _configuration = configuration;

        }
        public Response Register(RegisterUserDTO reUser)
        {
            Response respones = new Response();
            HttpRequest<User> httpUser = new HttpRequest<User>(_context);
            try
            {
                
                string description = _userRepository.CheckUserInfo(reUser.username, reUser.email);
                if(description!=null)
                {
                    _logger.LogError(description);
                    respones.status = "Error";
                    respones.data = description;
                    return respones;
                }
                reUser.password = EncodingPassword.EncodingUTF8(reUser.password);
                User newUser = _mapper.Map<User>(reUser);
                _userRepository.AddNew(newUser);
                _userRepository.Save();
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
            List<User> allUsers = _userRepository.FindAllData();
            IEnumerable<UserDTO> listUser = _mapper.Map<IEnumerable<UserDTO>>(allUsers);
            Response response = new Response();
            
            List<User> users = new List<User>();
            int index = (page - 1) * 10;
            if(index> allUsers.Count())
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
            string encodePass =EncodingPassword.EncodingUTF8(user.password);
            string description = _userRepository.CheckUserLogin(user.username, encodePass);
            if (description == null)
            {
                User loginUser = _userRepository.FindByUsername(user.username);
                TokenGenarate accessToken = new TokenGenarate(_configuration);
                string token =  accessToken.GenerateAccessToken(loginUser);
                respones.status = "Success";
                respones.data = token;
                return respones;
            }
            respones.status = "Error";
            respones.data = description;
            return respones;
        }
    }
}
