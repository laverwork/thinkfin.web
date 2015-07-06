using System;

namespace thinkfin.web.Infrastructure.Caching
{
    public static class CacheExtensions
    {
        public static T RetreiveFromCache<T>(this ICache cache, object cacheLock, string cacheKey, DateTime cacheExpiry, Func<T> notInCacheMethod) where T : class
        {
            //See if the data is already cached
            var data = cache.Get<T>(cacheKey);

            if (data != null)
                return data;

            lock (cacheLock)
            {
                //double check in case cache was locked by idetical call
                data = cache.Get<T>(cacheKey);

                if (data != null)
                    return data;

                data = notInCacheMethod();

                cache.AddOrUpdate(cacheKey, data, cacheExpiry);
                return data;
            }
        }
    }
}