using authentication.DTO.user;
using authentication.Service;
using Microsoft.AspNetCore.Mvc;

namespace authentication.Controller{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase{
        private readonly IUserService _userService = userService;

        [HttpGet("{id}")]
        public IActionResult GetUser(int id){
            var user = _userService.GetUserById(id);

            return user == null ? NotFound() : Ok(user) ;
        }

        [HttpGet]
        public IActionResult GetAllUser(){
            var users = _userService.GetAllUser();

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RequestCreateUserDTO userDto){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var user = new Domain.User{Name = userDto.Name, Email = userDto.Email, Password = userDto.Password};

            var newUser = await _userService.CreateUser(user);
            var response = new ResponseCreateUserDTO{Id = newUser.Id, Name = newUser.Name, Email = newUser.Email};

            return CreatedAtAction(nameof(GetUser), new {id = response.Id}, response); // Set the Location header with a URL to get the newly created resource
        }
    }
}