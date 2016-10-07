using System;
using System.Web;

namespace HomeProperty.WebApp {
    public class CacheManager : ICacheManager {
        public T GetOrSet<T>(string cacheKey, Func<T> getDataCallback) {
            T data = (T)HttpContext.Current.Cache.Get(cacheKey);
            if (data == null) {
                data = getDataCallback();
                HttpContext.Current.Cache.Insert(cacheKey, data,
                null, DateTime.Now.AddMinutes(4320d),               // 3 days = 3 * 24 * 60
                System.Web.Caching.Cache.NoSlidingExpiration);
            }
            return data;
        }
    }
}