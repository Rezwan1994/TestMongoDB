using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace MongoDbTest
{
    public class MongoService
    {
        private readonly IMongoCollection<Student> _posts;

        public MongoService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDb:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
            _posts = database.GetCollection<Student>("Students");
        }

        public Task<List<Student>> GetPostsAsync() => _posts.Find(_ => true).ToListAsync();

        public Task CreatePostAsync(Student student) => _posts.InsertOneAsync(student);
    }
}
