using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using StackExchange.Redis;
using ZeroFormatter;

namespace ThreeTierApp.Core.Services
{
    public class RedisCacheService : ICacheService
    {
        private readonly IDatabase _redisDatabase;

        public RedisCacheService(IConnectionMultiplexer redis)
        {
            _redisDatabase = redis.GetDatabase();
        }

        public async Task<T> GetCacheData<T>(string key)
        {
            try
            {
                var cachedData = await _redisDatabase.StringGetAsync(key);
                return cachedData.HasValue
                    ? ZeroFormatterSerializer.Deserialize<T>(cachedData)
                    : default;
            }
            catch (Exception ex)
            {
                // Log and rethrow exception to ensure calling code is aware
                Console.Error.WriteLine($"Error while getting cache data for key '{key}': {ex.Message}");
                throw new ApplicationException("An error occurred while retrieving data from the cache.", ex);
            }
        }

        public async Task SetCacheData<T>(string key, T data, TimeSpan expiration)
        {
            try
            {
                // Serialize the data using ZeroFormatter
                var serializedData = ZeroFormatterSerializer.Serialize(data);

                // Set the data in Redis with expiration
                await _redisDatabase.StringSetAsync(key, serializedData, expiration);
            }
            catch (BadImageFormatException ex)
            {
                // Handle BadImageFormatException, which can occur due to platform or architecture mismatch
                Console.Error.WriteLine($"Bad Image Format error while setting key '{key}': {ex.Message}");
                Console.Error.WriteLine("This might be due to mismatched assembly architecture or platform target issues.");
                throw new InvalidOperationException("There is a problem with the assembly format or platform compatibility.", ex);
            }
            catch (SerializationException ex)
            {
                // Handle ZeroFormatter serialization issues
                Console.Error.WriteLine($"Serialization error while setting key '{key}': {ex.Message}");
                throw new InvalidOperationException("There was an issue serializing the data.", ex);
            }
            catch (Exception ex)
            {
                // Handle other general exceptions
                Console.Error.WriteLine($"Unexpected error while setting key '{key}': {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while setting data in the cache.", ex);
            }
        }


        public async Task DeleteCacheData(string key)
        {
            try
            {
                // Delete the data from Redis
                await _redisDatabase.KeyDeleteAsync(key);
            }
            catch (Exception ex)
            {
                // Handle potential errors while deleting from Redis
                Console.Error.WriteLine($"Error while deleting cache data for key '{key}': {ex.Message}");
                throw new ApplicationException("An error occurred while deleting data from the cache.", ex);
            }
        }
    }
}
