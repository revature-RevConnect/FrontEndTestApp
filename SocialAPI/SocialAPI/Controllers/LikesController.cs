using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Data.DataContext;
using SocialAPI.Data.Models;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikesController : Controller
    {
        private readonly ILogger<LikesController> _logger;
        private readonly SocialContext _sc;

        public LikesController(ILogger<LikesController> logger, SocialContext sc)
        {
            _logger = logger;
            _sc = sc;
        }
        [HttpGet("{postID}")]
        public async Task<ActionResult<List<Like>>> GetPostLikesCount(int postID)
        {
            var likes = await _sc.Likes
                    .Where(b => b.postID == postID).ToListAsync();
            return likes.ToList();
        }
        [HttpPost("post")]
        public async Task <ActionResult<Like>> LikePost(Like newLike)
        {
            var likeExists =await _sc.Likes.
                Where(b => b.postID == newLike.postID && b.authID == newLike.authID).FirstOrDefaultAsync();

            if (likeExists != null)
            {
                _sc.Likes.Remove(likeExists);
                await _sc.SaveChangesAsync();
                return new Like() { likeID = -1, authID=likeExists.authID };
            }
            else
            {
                await _sc.Likes.AddRangeAsync(newLike);
            }
            //await _sc.Likes.AddRangeAsync(newLike);

            await _sc.SaveChangesAsync();
            return newLike;
        }

        [HttpPost("comment")]
        public async Task<ActionResult<Like>> LikeComment(Like newLike)
        {
            await _sc.Likes.AddRangeAsync(newLike);
            await _sc.SaveChangesAsync();
            return newLike;
        }
    }
}
