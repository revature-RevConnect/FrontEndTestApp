using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialAPI.Data.DataContext;
using SocialAPI.Data.Models;

namespace SocialAPI.Controllers
{


    public class BlobConfig
    {
        public string _connection { get; set; }
    }

    [Route("[controller]")]
    [ApiController]
    public class PhotosController : Controller
    {

        public SocialContext _sc { get; set; }
        public BlobConfig _config { get; set; }
        public ILogger<PhotosController> _logger { get; set; }

   
        public PhotosController(BlobConfig config, SocialContext sc, ILogger<PhotosController> logger)

        {

            _config = config;
            _sc = sc;
            _logger = logger;
        }

        [HttpPost("images")]
        public async Task<ActionResult<User>> upload([FromQuery] string authID, IFormFile postedFile)
        {
 
            string path = $"https://dangagne.blob.core.windows.net/revconnect/{authID}";
            var user = await _sc.Users
                    .Where(b => b.authID == authID).FirstAsync();
            user.profilePicture = path;
            await _sc.SaveChangesAsync();


           BlobContainerClient container = new BlobContainerClient(_config._connection, "revconnect");
           BlobClient blob = container.GetBlobClient(authID);
            await blob.UploadAsync(
                postedFile.OpenReadStream(),
                new BlobHttpHeaders 
                { ContentType = postedFile.ContentType }
                );


            return user;

            
        }
    }
}
