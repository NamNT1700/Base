using AutoMapper;
using Loggger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DTO;
using Model.DTO.USERDTO;
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
        [HttpPost("Users")]
        public IActionResult GetAllUsers(BaseRequest<User> baseRequest)
        {
            Response res = _userService.GetAllUsers(baseRequest);
            return Ok(res);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO user)
        {
            Response res = _userService.Login(user);
            return Ok(res);
        }
        [HttpDelete("User")]
        public IActionResult Delete(DeleteUserDTO deleteUserDTO)
        {
            Response res = _userService.DeleteUser(deleteUserDTO);
            return Ok(res);
        }
        [HttpPut("ActiveUser")]
       // [Authorize(Roles="Admin")]
        public IActionResult UpdateStatusToInActive(IdUserUpdateStatus idUserUpdate)
        {
            Response res = _userService.ChangeStatusUser(idUserUpdate);
            return Ok(res);
        }
       
       
       
    }
}
