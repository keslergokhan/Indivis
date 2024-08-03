using Indivis.Core.Application.Dtos.CoreEntityDtos.Language.Reads;
using Indivis.Core.Application.Exceptions.Systems;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Indivis.Presentation.WebUICms.Helpers
{
    public static class CookieExtensions
    {
        public static string LanguageKey = "cms_language";
        /// <summary>
        /// İletilen objeyi json çevirerek cookie ekler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseCookies"></param>
        /// <param name="key"></param>
        /// <param name="t"></param>
        public static void CookieSetObject<T>(this HttpContext httpContext,string key,T t)
            where T : class, new()
        {

            string json = JsonSerializer.Serialize(t);
            httpContext.Response.Cookies.Append(key,json);
        }

        /// <summary>
        /// Key değerine sahip olan json objesini çözümler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookies"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T CookieGetObject<T>(this HttpContext httpContext, string key)
            where T : class, new()
        {
            KeyValuePair<string,string> findCookie = httpContext.Request.Cookies.FirstOrDefault(x => x.Key == key);

            if (!string.IsNullOrEmpty(findCookie.Value))
            {
                T t = JsonSerializer.Deserialize<T>(findCookie.Value);
                return t;
            }
            else
            {
                return default(T);
            }
        }

        public static Guid GetCurrentLanguageId(this HttpContext httpContext)
        {
            ReadLanguageDto language = httpContext.CookieGetObject<ReadLanguageDto>(CookieExtensions.LanguageKey);

            if (language == null)
            {
                throw new LanguageNotFaundException();
            }

            return language.Id;
        }

    }
}
