using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace LojinhaPri.FIAP.Infrastructure.Redis
{
    public class RedisCache : IRedisCache
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;

        public RedisCache(IConfiguration config)
        {
            _redis = ConnectionMultiplexer.Connect(config.GetSection("Azure:Redis").Value);
            _db = _redis.GetDatabase();
        }

        public string Get(string key)
        {
            return _db.StringGet(key);
        }

        public void Set(string key, string value)
        {
            _db.StringSet(key, value);
        }
    }
}
