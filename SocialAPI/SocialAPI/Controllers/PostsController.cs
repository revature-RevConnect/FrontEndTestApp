using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Data.DataContext;
using SocialAPI.Data.Models;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : Controller
    {
        private readonly ILogger<PostsController> _logger;
        private readonly SocialContext _sc;

        public PostsController(ILogger<PostsController> logger, SocialContext sc)
        {
            _logger = logger;
            _sc = sc;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> Post(Post post)
        {
            await _sc.AddRangeAsync(post);
            await _sc.SaveChangesAsync();
            return post;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Post>>> Get(string id)
        {
            var posts = await _sc.Posts
                .Where(b => b.authID == id).ToListAsync();


            return posts.ToList();
        }
        [HttpGet("all")]
        
        public async Task<ActionResult<List<Post>>> Get()
        {
            var posts = await _sc.Posts.OrderByDescending(i=>i.postID).ToListAsync();

            return posts.ToList();
        }
    }
}
