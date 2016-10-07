using System;

namespace HomeProperty.WebApp {
    public interface ICacheManager {
        T GetOrSet<T>(string cacheKey, Func<T> getDataCallback);
    }
}