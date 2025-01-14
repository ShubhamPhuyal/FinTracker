using System.Text.Json;

namespace FinTracker.Abstraction
{
    public class BaseService<T> where T : class
    {
        protected static List<T> GetAll(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<List<T>>(json);

            return result ?? new List<T>();
        }

        protected static void SaveAll(List<T> entity, string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");
            }

            var json = JsonSerializer.Serialize(entity);
            File.WriteAllText(filePath, json);
        }
    }
}