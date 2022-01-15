using System.Collections.Generic;
using System.Threading.Tasks;
using BjertorpAPI.Models;
using BjertorpAPI.Services;
using Microsoft.AspNetCore.Mvc; 

namespace BjertorpAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly PostsService _postsService;
    
    public PostsController(PostsService postsService)
    {
        _postsService = postsService;
    }

    [HttpGet]
    public async Task<List<Posts>> Get()
    {
     var posts =  await _postsService.GetAsync();  
     return posts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Posts>> GetById(string id)
    {
      var post = await _postsService.GetAsync(id); 
      if(post is null) return NotFound("No post exist with privided id"); 
      return post; 
    }
  }  
}