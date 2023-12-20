using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utils
{
    public static class Validator
    {
        public static object ProperyInfo { get; private set; }

        public static bool IsValid(object obj)
        {
            Type objectType = obj.GetType();

            PropertyInfo[] properties = objectType
                .GetProperties()
                .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute)
                .IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                var attributes = property
                    .GetCustomAttributes(true)
                    .Where(ca => typeof(MyValidationAttribute)
                    .IsAssignableFrom(ca.GetType()))
                    .Cast<MyValidationAttribute>();

                foreach (var attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
