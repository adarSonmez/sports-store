using System.Text.Json;

namespace SportsStore.Infrastructure;

// Extension methods for simplifying the storage and retrieval of JSON-serialized objects in session data.
public static class SessionExtensions
{
    // Extension method to store an object in the session as JSON.
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    // Extension method to retrieve and deserialize an object from session data.
    // Returns default value if the key is not found or the session data is null.
    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData == null
            ? default
            : JsonSerializer.Deserialize<T>(sessionData);
    }
}