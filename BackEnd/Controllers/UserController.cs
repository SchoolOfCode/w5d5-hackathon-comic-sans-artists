using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

   
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        try {
            var users = await _userRepository.GetAll();

            return Ok(users);
        }
        catch (Exception){
            return NotFound($"/users/ Not Found");
        }
    }

    [HttpGet("{month}")]
    public async Task<IActionResult> GetByMonth(string month)
    {
        try {

            var users = await _userRepository.GetAllByMonth(month);

            return Ok(users);
        }
        catch (Exception){
            return NotFound($"/users/{month} Not Found");
        }
    }

    [HttpPost]
    public async Task<IActionResult> InsertNewUser([FromBody] User user)
    {
        try {
            var newUser = await _userRepository.Insert(user);
            return Created($"/users/{user.Id}", newUser);
        }
        catch (Exception){

            return BadRequest("Could not create user, check request and try again.");
        }
    }
}

