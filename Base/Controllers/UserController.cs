using AutoMapper;
using Base.Datas.DTO;
using Base.Datas.IRepository;
using Base.Datas.Respones;
using Base.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private IUserRepository _userRepository;
        private IUserService _userService;

        public UserController(IMapper mapper, IUserRepository userRepository, IUserService userService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDTO user)
        {
            Response res = _userService.Register(user);
            return Ok(res);
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            Response res = _userService.GetAllUsers();
            return Ok(res);
        }
    }
}
