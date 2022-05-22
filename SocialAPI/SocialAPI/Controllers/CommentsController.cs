using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Data.DataContext;
using SocialAPI.Data.Models;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {

        private readonly ILogger<CommentsController> _logger;
        private readonly SocialContext _sc;

        public CommentsController(ILogger<CommentsController> logger, SocialContext sc)
        {
            _logger = logger;
            _sc = sc;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Post(Comment comment)
        {
            await _sc.AddRangeAsync(comment);
            await _sc.SaveChangesAsync();
            return comment;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Comment>>> Get(string id)
        {
            var comments = await _sc.Comments
                .Where(b => b.authID == id).ToListAsync();


            return comments.ToList();
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<Comment>>> Get()
        {
            var comments = await _sc.Comments.ToListAsync();

            return comments.ToList();
        }
        [HttpGet("all/{postID}")]
        public async Task<ActionResult<List<Comment>>> GetAllByID(int postID)
        {
            var comments = await _sc.Comments
                .Where(b => b.postID == postID).ToListAsync();

            return comments.ToList();
        }

    }   
}
