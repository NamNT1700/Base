using AutoMapper;
using Loggger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Repository.IRepository;
using Services.IServices;
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
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody] RegisterUserDTO user)
        {
            Response res = _userService.Register(user);
            return Ok(res);
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers(int page)
        {
            Response res = _userService.GetAllUsers(page);
            return Ok(res);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO user)
        {
            Response res = _userService.Login(user);
            return Ok(res);
        }
    }
}
