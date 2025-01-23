using System.Threading.Tasks;
using System;

public interface ICacheService
{
    Task SetCacheData<T>(string key, T data, TimeSpan expiration);
    Task<T> GetCacheData<T>(string key);
    Task DeleteCacheData(string key);
}
