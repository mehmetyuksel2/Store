using System.Text.Json;

namespace StoreApp.Infrastructe.Extensions
{//HttpContext.Session.(dan sonra burada implemente edilen metodlar gelir)
    public static class SessionExtension
    {// iki metodda aynı işlevi görür. birinde objeye bağlı çalışır diğeri T parametresine bağlı yani dinamik.
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session,string key)
        {
            var data = session.GetString(key);
            return data is null
                ? default(T) // sesion boş ise verilen objenin default hali gelir. yok ise null değer döner
                : JsonSerializer.Deserialize<T>(data);// session dolu ise içindekini döndürür
        }
    }
}