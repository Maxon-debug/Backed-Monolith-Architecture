using AutoMapper;
using MaxonEventManagement.Models;
using MaxonEventManagement.Services;
using MaxonEventManagement.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaxonEventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        private readonly IMapper _mapper;
        private readonly IJwt _jwt;
        public UserController(IUser userService, IMapper mapper, IJwt jwt)
        {
            _mapper = mapper;
            _userService = userService;
            _jwt = jwt;
        }
        [HttpPost("register")]
        public ActionResult<string> RegisterUser(AddUserDto addUserDto)
        {
            var user = _mapper.Map<User>(addUserDto);
            //encrypting password using Bcrypt
            user.Password = BCrypt.Net.BCrypt.HashPassword(addUserDto.Password);
            //Check if the user with the email already exists or else register the user
            var checkuser = _userService.GetUserByEmail(addUserDto.Email);
            if (checkuser != null)
            {
                return BadRequest("Email ALready Exists");
            }
            var response = _userService.RegisterUser(user);
            return Ok(response);    
        }
        [HttpPost("login")]
        public ActionResult<string> LoginUser(LogUserDto logUserDto)
        {
            var checkUser = _userService.GetUserByEmail(logUserDto.Email);
            if(checkUser == null)
            {
                return BadRequest(" Invalid Credentials");
            }
            
            //verify password
            var isCorrect = BCrypt.Net.BCrypt.Verify(logUserDto.Password, checkUser.Password);
            if (!isCorrect)
            {
                return BadRequest("Invalid Credentials");
            }
            //returning the generated token
            var token = _jwt.GenerateToken(checkUser);
            return Ok(token);
           
        }

    }
}
