using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using Newtonsoft.Json;
using System.Drawing.Imaging;

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

        //[HttpPost]
        //public async Task<IActionResult> CreatePost([FromBody] StudentDto dto)
        //{
        //    var student = new Drowing
        //    {
        //        StudentId = dto.StudentId,
        //        Name = dto.Name,
        //        Age = dto.Age
        //    };

        //    await _mongo.CreatePostAsync(student);
        //    return Ok(student);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var posts = await _mongo.GetPostsAsync(3905);
                MergeDrawingsWithImages(posts);
                return Ok(posts);
            }
            catch (Exception ex) { 
            }
            return null;
        }
        private async Task MergeDrawingsWithImages(List<DrowInfo> drawInfos)
        {
            string imageUrl = "https://testfiles.bestbrains.com:4443/BBDocs/Std/172140/Pages/E_H1_R/ce46f1a2-a9ac-480a-9272-bd5efcfe46f4.jpg";
            if (string.IsNullOrEmpty(imageUrl)) return;

            using var httpClient = new HttpClient();
            var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

            using var ms = new MemoryStream(imageBytes);
            using var image = new Bitmap(ms);
            using var g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            foreach (var drawInfo in drawInfos)
            {
                if (drawInfo.StrokeData == null || !drawInfo.StrokeData.Any())
                    continue;

                foreach (var stroke in drawInfo.StrokeData)
                {
                    var pen = new Pen(Color.Black, (float)stroke.StrokeWidth)
                    {
                        StartCap = LineCap.Round,
                        EndCap = LineCap.Round,
                        LineJoin = LineJoin.Round
                    };

                    var points = stroke.StrokePoints;
                    if (points == null || points.Count < 2) continue;

                    for (int i = 1; i < points.Count; i++)
                    {
                        var p1 = points[i - 1];
                        var p2 = points[i];

                        g.DrawLine(
                            pen,
                            (float)p1.X, (float)p1.Y,
                            (float)p2.X, (float)p2.Y
                        );
                    }
                }
            }

            // Save the final merged image (only once)
            var outputPath = "F:\\Projects\\POC\\TestMongoDB\\MongoDbTest\\MongoDbTest\\merged.png";
            image.Save(outputPath, ImageFormat.Png);
        }



    }
}
