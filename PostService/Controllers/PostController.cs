using Microsoft.AspNetCore.Mvc;
using BloggingPlatform.Shared.Models;

namespace PostService.Controllers;

[ApiController]
[Route("posts")]
public class PostsController : ControllerBase
{
    private static readonly List<BlogPostDto> _posts = new();

    [HttpPost]
    public IActionResult CreatePost([FromBody] BlogPostDto post)
    {
        post.Id = Guid.NewGuid();
        _posts.Add(post);
        return Ok(post);
    }

    [HttpGet]
    public IActionResult GetAllPosts()
    {
        return Ok(_posts);
    }

    [HttpGet("{id}")]
    public IActionResult GetPostById(Guid id)
    {
        var post = _posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return NotFound("Post not found");
        }
        return Ok(post);
    }
}
