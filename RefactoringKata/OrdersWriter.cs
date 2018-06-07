using System.Collections.Generic;
using System.Text;
using static RefactoringKata.JsonBuilder;

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
                sb.Append(BuildOrderJson(OrderData(order)));
                sb.Append(BuildProductsJson(order));
            }

            if (_orders.GetOrdersCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            return sb.Append("]}").ToString();
        }

        private Dictionary<string, int> OrderData(Order order)
        {
            return new Dictionary<string, int> {{"id", order.GetOrderId()}};
        }
    }
}