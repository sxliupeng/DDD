using System;
using System.Collections;
using System.Web;
using System.Web.Caching;

namespace CompanyName.ProductName.Mvc.Common
{
    public sealed class CacheService
    {
        private CacheService() { }

        private static readonly Cache cache;
        private static int factor = 5;
        public static readonly int DayFactor = 17280;
        public static readonly int HourFactor = 720;
        public static readonly int MinuteFactor = 12;
        public static readonly double SecondFactor = 0.2;

        static CacheService()
        {
            HttpContext context = HttpContext.Current;
            if (context != null)
            {
                cache = context.Cache;
            }
            else
            {
                cache = HttpRuntime.Cache;
            }
        }

        public static void ReSetFactor(int cacheFactor)
        {
            factor = cacheFactor;
        }
        public static void Clear()
        {
            IDictionaryEnumerator CacheEnum = cache.GetEnumerator();
            ArrayList al = new ArrayList();
            while (CacheEnum.MoveNext())
            {
                al.Add(CacheEnum.Key);
            }

            foreach (string key in al)
            {
                cache.Remove(key);
            }
        }
        public static void Remove(string key)
        {
            cache.Remove(key);
        }
        public static void Insert(string key, object obj)
        {
            Insert(key, obj, null, 1);
        }
        public static void Insert(string key, object obj, CacheDependency dep)
        {
            Insert(key, obj, dep, MinuteFactor * 3);
        }
        public static void Insert(string key, object obj, double seconds)
        {
            Insert(key, obj, null, seconds);
        }
        public static void Insert(string key, object obj, double seconds, CacheItemPriority priority)
        {
            Insert(key, obj, null, seconds, priority);
        }
        public static void Insert(string key, object obj, CacheDependency dep, double seconds)
        {
            Insert(key, obj, dep, seconds, CacheItemPriority.Normal);
        }
        public static void Insert(string key, object obj, CacheDependency dep, double seconds, CacheItemPriority priority)
        {
            if (obj != null)
            {
                cache.Insert(key, obj, dep, DateTime.Now.AddSeconds(factor * seconds), TimeSpan.Zero, priority, null);
            }
        }
        public static void Max(string key, object obj)
        {
            Max(key, obj, null);
        }
        public static void Max(string key, object obj, CacheDependency dep)
        {
            if (obj != null)
            {
                cache.Insert(key, obj, dep, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.NotRemovable, null);
            }
        }
        public static object Get(string key)
        {
            return cache[key];
        }
        public static long SecondFactorCalculate(double seconds)
        {
            return Convert.ToInt64(Math.Round(seconds * SecondFactor));
        }
    }
}
