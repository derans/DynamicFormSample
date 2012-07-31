using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace Core.Extensions
{
    public static class ObjectExtensions
    {
        public static List<KeyValuePair<string, object>> ToParameterList(this object o)
        {
            var parameters = new List<KeyValuePair<string, object>>();
            var properties = o.GetType().GetProperties();

            foreach (var property in properties)
            {
                var value = property.GetValue(o, null);
                if (value != null)
                {
                    if (!(value is string) && value is IEnumerable)
                    {
                        foreach (var val in (IEnumerable)value)
                        {
                            parameters.Add(new KeyValuePair<string, object>(property.Name, val));
                        }
                    } else {
                        parameters.Add(new KeyValuePair<string, object>(property.Name, value));
                    }
                }
            }

            return parameters;
        }

        public static string ToQueryString(this object o)
        {
            var parameters = o.ToParameterList();

            return "?" + string.Join("&", parameters.Select(x => x.Key + "=" + x.Value));
        }
    }
}