using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MyAsp6Store.ShopUI.Extentions
{
    public static class SessionExtentions
    {
        public static void SetJson(this ISession session,string key,object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session,string key)
        {
            var JsonObject = session.GetString(key);
            if (string.IsNullOrEmpty(JsonObject))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(JsonObject);
        }
    }
}
