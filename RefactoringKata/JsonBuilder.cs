using System;
using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public static class JsonBuilder
    {

        public static string BuildProductJson(Dictionary<string, object> productData)
        {
            return "{" + $"{ProductPropertiesAsJson(productData)}" + "}, ";
        }

        private static string ProductPropertiesAsJson(Dictionary<string, object> data)
        {
            return String.Join(", ", data.Select(item => {
                if (item.Value is double)
                    return $"\"{item.Key}\": {item.Value}";
                return $"\"{item.Key}\": \"{item.Value}\"";
            }));
        }
    }
}