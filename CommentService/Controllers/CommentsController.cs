using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using BloggingPlatform.Shared.Models;

namespace CommentService.Controllers;

[ApiController]
[Route("comments")]
public class CommentsController : ControllerBase
{
    private static readonly List<CommentDto> _comments = new();
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public CommentsController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> AddComment([FromBody] CommentDto comment)
    {
        // Validate postId by calling PostService
        var postServiceUrl = _configuration["PostServiceUrl"];
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync($"{postServiceUrl}/posts/{comment.PostId}");
        if (!response.IsSuccessStatusCode)
        {
            return StatusCode((int)response.StatusCode, "Could not validate postId");
        }

        var post = await response.Content.ReadFromJsonAsync<BlogPostDto>();
        if (post == null)
        {
            return BadRequest("Invalid postId");
        }

        // If the postId is valid, add the comment
        _comments.Add(comment);
        return Ok(comment);
    }

    [HttpGet("{postId}")]
    public IActionResult GetComments(Guid postId)
    {
    var results = _comments.Where(c => c.PostId == postId).ToList();
    return Ok(results);
    }

}