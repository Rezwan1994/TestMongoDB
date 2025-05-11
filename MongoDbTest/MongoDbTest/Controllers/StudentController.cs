using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace MongoDbTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly MongoService _mongo;

        public PostsController(MongoService mongo)
        {
            _mongo = mongo;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] StudentDto dto)
        {
            var student = new Student
            {
                StudentId = dto.StudentId,
                Name = dto.Name,
                Age = dto.Age
            };

            await _mongo.CreatePostAsync(student);
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _mongo.GetPostsAsync();
            return Ok(posts);
        }
    }
}
