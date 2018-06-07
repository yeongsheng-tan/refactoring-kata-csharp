using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public static class JsonBuilder
    {
        public static string BuildOrderJson(Dictionary<string, int> orderData) => "{" + String.Join("",
            orderData.Select(ord => $"\"{ord.Key}\": {ord.Value}, "));

        public static string BuildProductsJson(Order order)
        {
            var sb = new StringBuilder("\"products\": [");
            for (var j = 0; j < order.GetProductsCount(); j++)
            {
                sb.Append(BuildProductJson(order.GetProduct(j).Data()));
            }

            if (order.GetProductsCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append("]");
            sb.Append("}, ");
            return sb.ToString();
        }

        public static string BuildProductJson(Dictionary<string, object> productData) => "{" + $"{ProductPropertiesAsJson(productData)}" + "}, ";

        private static string ProductPropertiesAsJson(Dictionary<string, object> data) => String.Join(", ", data.Select(item =>
        {
            if (item.Value is double)
                return $"\"{item.Key}\": {item.Value}";
            return $"\"{item.Key}\": \"{item.Value}\"";
        }));
    }
}