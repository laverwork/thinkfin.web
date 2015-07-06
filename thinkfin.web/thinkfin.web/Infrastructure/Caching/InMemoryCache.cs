using System;
using System.Runtime.Caching;

namespace thinkfin.web.Infrastructure.Caching
{
    public class InMemoryCache : ICache
    {
        private readonly MemoryCache _memoryCache;

        public InMemoryCache()
        {
            IsDisposed = false;

            _memoryCache = new MemoryCache("defaultCache");
        }

        public bool IsDisposed { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                if (disposing)
                {
                    // Dispose managed resources.
                    _memoryCache.Dispose();
                }
            }

            IsDisposed = true;
        }

        public void AddOrUpdate(string key, object value, DateTime timeToCache)
        {
            _memoryCache.Set(key, value, new DateTimeOffset(timeToCache));
        }

        public bool TryGet<TItem>(string key, out TItem value) where TItem : class
        {
            if (_memoryCache.Contains(key) == false)
            {
                value = null;
                return false;
            }

            value = _memoryCache.Get(key) as TItem;
            return true;
        }

        public TItem Get<TItem>(string key) where TItem : class
        {
            return _memoryCache.Get(key) as TItem;
        }
    }
}