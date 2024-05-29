using System.Reflection;
using System.Text;


namespace SerializationReflection
{
    public class Serialization
    {
        public static string Serialize(object obj)
        {
            Type type = obj.GetType();
            FieldInfo[] fields = type.GetFields();
            StringBuilder sb = new StringBuilder();

            foreach (var field in fields)
            {
                string name = field.Name;
                string value = field.GetValue(obj)?.ToString()!;
                sb.Append($"{name}={value}&");
            }

            // Удаляем последний разделитель
            if (sb.Length > 0)
            {
                sb.Length--; // удаляем &
            }

            return sb.ToString();
        }

        public static T Deserialize<T>(string serializedString) where T : new()
        {
            T obj = new();
            Type type = typeof(T);

            string[] keyValuePairs = serializedString.Split('&');

            foreach (var pair in keyValuePairs)
            {
                string[] keyValue = pair.Split('=');
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0];
                    string value = keyValue[1];

                    FieldInfo field = type.GetField(key)!;
                    if (field != null && field.IsPublic)
                    {
                        field.SetValue(obj, Convert.ChangeType(value, field.FieldType));
                    }
                }
            }

            return obj;
        }
    }
}
