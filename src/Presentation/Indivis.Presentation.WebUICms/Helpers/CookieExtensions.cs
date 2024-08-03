using System.Text.Json;
using System.Text.Json.Serialization;

namespace Indivis.Presentation.WebUICms.Helpers
{
    public static class CookieExtensions
    {
        /// <summary>
        /// İletilen objeyi json çevirerek cookie ekler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="responseCookies"></param>
        /// <param name="key"></param>
        /// <param name="t"></param>
        public static void SetObject<T>(this IResponseCookies responseCookies,string key,T t)
            where T : class, new()
        {

            string json = JsonSerializer.Serialize(responseCookies);
            responseCookies.Append(key,json);
        }

        /// <summary>
        /// Key değerine sahip olan json objesini çözümler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cookies"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this IRequestCookieCollection cookies,string key)
            where T : class, new()
        {
            KeyValuePair<string,string> findCookie = cookies.FirstOrDefault(x => x.Key == key);

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

    }
}
