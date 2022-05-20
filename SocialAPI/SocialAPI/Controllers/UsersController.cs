using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Data.DataContext;
using SocialAPI.Data.Models;

namespace SocialAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly SocialContext _sc;

        public UsersController(ILogger<UsersController> logger, SocialContext sc)
        {
            _logger = logger;
            _sc = sc;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await _sc.AddRangeAsync(user);
            await _sc.SaveChangesAsync();
            return user;
        }

        [HttpGet("{authID}")]
        public async Task<ActionResult<User>> Login(string authID)
        {
            var activeUser = await _sc.Users
                .Where(b => b.authID == authID).FirstAsync();

                return activeUser;
            
        }

        [HttpPut("picture")]
        public async Task<ActionResult<User>> ChangePicture(User user)
        {
            var newUser = await _sc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.profilePicture = user.profilePicture;
            await _sc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("username")]
        public async Task<ActionResult<User>> ChangeUsername(User user)
        {
            var newUser = await _sc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.name = user.name;
            await _sc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }

        [HttpPut("aboutMe")]
        public async Task<ActionResult<User>> ChangeAboutMe(User user)
        {
            var newUser = await _sc.Users
                        .Where(b => b.authID == user.authID).FirstAsync();
            newUser.aboutMe = user.aboutMe;
            await _sc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }
        [HttpPut("inactive")]
        public async Task<ActionResult> SetUserToInactive(User oldUser)
        {
            var user=await _sc.Users
                    .Where(b => b.authID == oldUser.authID).FirstAsync();
            user.active = oldUser.active;
            await _sc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }
        [HttpPut("active")]
        public async Task<ActionResult> SetUserToActive(User newUser)
        {
            var user = await _sc.Users
                    .Where(b => b.authID == newUser.authID).FirstAsync();
            user.active = newUser.active;
            await _sc.SaveChangesAsync();

            return new ContentResult() { StatusCode = 200 };
        }
    }
    
}
