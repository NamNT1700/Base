using AutoMapper;
using Loggger;
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
        [HttpGet("Users")]
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
        [HttpDelete("User")]
        public IActionResult Delete(DeleteUserDTO deleteUserDTO)
        {
            Response res = _userService.DeleteUser(deleteUserDTO);
            return Ok(res);
        }
        [HttpPut("ActiveUser")]
        public IActionResult UpdateStatusToInActive(IdUserUpdateStatus idUserUpdate)
        {
            Response res = _userService.ChangeStatusUserToInActive(idUserUpdate);
            return Ok(res);
        }
        [HttpGet("ActiveUsers")]
        public IActionResult GetAllActiveUser()
        {
            Response res = _userService.FindUserActive();
            return Ok(res);
        }
        [HttpPut("InActiveUsers")]
        public IActionResult UpdateStatusToActive(IdUserUpdateStatus idUserUpdate)
        {
            Response res = _userService.ChangeStatusUserToInActive(idUserUpdate);
            return Ok(res);
        }
        [HttpGet("InActiveUsers")]
        public IActionResult GetAllInActiveUser()
        {
            Response res = _userService.FindUsersInactive();
            return Ok(res);
        }
    }
}
