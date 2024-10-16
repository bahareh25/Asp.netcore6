using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHostedServiceSample.PostSample.Infrastructures;
using MyHostedServiceSample.PostSample.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MyHostedServiceSample.PostSample.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly PostService _postService;
    private readonly PostCache _postCache;

    public PostsController(PostService postService,PostCache postCache)
    {
        _postService = postService;
        _postCache = postCache;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_postCache.Get());
    }
    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _postService.GetById(id));
    }
}
