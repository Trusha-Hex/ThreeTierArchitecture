﻿using System;
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

        // Get cache data for a specific employee by employee.id
        public async Task<T> GetCacheData<T>(string key)
        {
            try
            {
                var cachedData = await _redisDatabase.HashGetAsync("employees", key); // Fetch data from 'employees' hash by employee.id
                return cachedData.HasValue
                    ? ZeroFormatterSerializer.Deserialize<T>(cachedData) // Deserialize using ZeroFormatter
                    : default;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while getting cache data for key '{key}': {ex.Message}");
                throw new ApplicationException("An error occurred while retrieving data from the cache.", ex);
            }
        }

        // Set cache data using employee.id as the key
        public async Task SetCacheData<T>(string key, T data)
        {
            try
            {
                var serializedData = ZeroFormatterSerializer.Serialize(data); // Serialize data using ZeroFormatter

                // Store the serialized data in the Redis hash with 'employees' as the hash key
                await _redisDatabase.HashSetAsync("employees", key, serializedData);
            }
            catch (BadImageFormatException ex)
            {
                Console.Error.WriteLine($"Bad Image Format error while setting key '{key}': {ex.Message}");
                Console.Error.WriteLine("This might be due to mismatched assembly architecture or platform target issues.");
                throw new InvalidOperationException("There is a problem with the assembly format or platform compatibility.", ex);
            }
            catch (SerializationException ex)
            {
                Console.Error.WriteLine($"Serialization error while setting key '{key}': {ex.Message}");
                throw new InvalidOperationException("There was an issue serializing the data.", ex);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error while setting key '{key}': {ex.Message}");
                throw new ApplicationException("An unexpected error occurred while setting data in the cache.", ex);
            }
        }

        // Delete cache data using employee.id as the key
        public async Task DeleteCacheData(string key)
        {
            try
            {
                // Remove the employee data from the 'employees' hash by employee.id
                await _redisDatabase.HashDeleteAsync("employees", key);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error while deleting cache data for key '{key}': {ex.Message}");
                throw new ApplicationException("An error occurred while deleting data from the cache.", ex);
            }
        }
    }
}
