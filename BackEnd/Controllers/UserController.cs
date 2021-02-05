using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


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
    public async Task<IActionResult> GetAll()
    {
        try {
            var books = await _bookRepository.GetAll();

            return Ok(books);
        }
        catch(Exception){

            return NotFound();
        }
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        try {
            var book = await _bookRepository.Get(id);

            return Ok(book);
        }
        catch (Exception){
            return NotFound($"/books/{id} Not Found");
        }
    }

    [HttpDelete("{id}")]
    public async void Delete(long id)
    {
        try
        {
            await _bookRepository.Delete(id);
        }
        catch(Exception){

            NotFound($"/books/{id} Not Found"); //this appears to never get returned
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] Book book)
    {
        try {
            var updatedBook = await _bookRepository.Update(new Book { Id = id, Title = book.Title, Author = book.Author });

            return Ok(updatedBook);
        }
        catch(Exception){

            return NotFound($"/books/{id} Not Found");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Book book)
    {
        try {
            var newBook = await _bookRepository.Insert(book);
            return Created($"/books/{book.Id}", newBook);
        }
        catch (Exception){

            return BadRequest("Could not create book, check request and try again.");
        }
    }
}

