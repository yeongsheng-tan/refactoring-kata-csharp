using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RefactoringKata
{
    public class OrdersWriter
    {
        private Orders _orders;

        public OrdersWriter(Orders orders)
        {
            _orders = orders;
        }

        public string GetContents()
        {
            var sb = new StringBuilder("{\"orders\": [");

            for (var i = 0; i < _orders.GetOrdersCount(); i++)
            {
                var order = _orders.GetOrder(i);
                sb.Append("{");
                sb.Append("\"id\": ");
                sb.Append(order.GetOrderId());
                sb.Append(", ");
                sb.Append("\"products\": [");

                for (var j = 0; j < order.GetProductsCount(); j++)
                {
                    var product = order.GetProduct(j);

                    Dictionary<string, object> productData = new Dictionary<string, object>();
                    productData.Add("code", product.Code);
                    productData.Add("color", getColorFor(product));
                    if (product.Size != Product.SIZE_NOT_APPLICABLE)
                    {
                        productData.Add("size", getSizeFor(product));
                    }
                    productData.Add("price", product.Price);
                    productData.Add("currency", product.Currency);

                    sb.Append("{");
                    sb.Append(toJson(productData));
                    sb.Append("}, ");
                }

                if (order.GetProductsCount() > 0)
                {
                    sb.Remove(sb.Length - 2, 2);
                }

                sb.Append("]");
                sb.Append("}, ");
            }

            if (_orders.GetOrdersCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.Append("]}").ToString();
        }

        private string toJson(Dictionary<string, object> data)
        {
            var sb = new StringBuilder();
            foreach (KeyValuePair<string, object> item in data)
            {
                if (item.Value is double)
                    sb.Append(string.Format("\"{0}\": {1}", item.Key, item.Value));
                else
                    sb.Append(string.Format("\"{0}\": \"{1}\"", item.Key, item.Value));
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        private string getSizeFor(Product product)
        {
            switch (product.Size)
            {
                case 1:
                    return "XS";
                case 2:
                    return "S";
                case 3:
                    return "M";
                case 4:
                    return "L";
                case 5:
                    return "XL";
                case 6:
                    return "XXL";
                default:
                    return "Invalid Size";
            }
        }

        private string getColorFor(Product product)
        {
            switch (product.Color)
            {
                case 1:
                    return "blue";
                case 2:
                    return "red";
                case 3:
                    return "yellow";
                default:
                    return "no color";
            }
        }
    }
}