using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace MongoDbTest
{
    public class MongoService
    {
        private readonly IMongoCollection<DrowInfo> _posts;

        public MongoService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDb:ConnectionString"]);
            var database = client.GetDatabase(config["MongoDb:DatabaseName"]);
            _posts = database.GetCollection<DrowInfo>("DrawInfo");
        }

        public Task<List<DrowInfo>> GetPostsAsync(int bookPageId)
        {
            return _posts.Find(d => d.BookPageId == 3905).ToListAsync();
        }

        public Task CreatePostAsync(DrowInfo student) => _posts.InsertOneAsync(student);
    }
}
