using AutoMapper;
using Base.Common;
using Base.Datas.DTO;
using Base.Datas.IRepository;
using Base.Datas.Repository;
using Base.Datas.Respones;
using Base.Models;
using Microsoft.AspNetCore.Mvc;
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

        public UserServices(IMapper mapper, IUserRepository userRepository)
        {
            //_repository = repository;
            _mapper = mapper;
            _userRepository = userRepository;
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
                if (ex.InnerException != null)
                {
                    respones.status = "Error";
                    respones.data = ex.InnerException.Message;
                    return respones;
                }
                respones.status = "Error";
                respones.data = ex.Message;
                return respones;
            }

        }
        public Response GetAllUsers()
        {
            IEnumerable <User> users = _userRepository.FindAllData();
            IEnumerable<UserDTO> listUser = _mapper.Map<IEnumerable<UserDTO>>(users);
            Response response = new Response();
            response.status = "Success";
            response.data = listUser;
            return response;
        }
    }
}
