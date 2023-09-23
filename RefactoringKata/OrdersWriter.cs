﻿using System.Text;

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
                    sb.Append("{");
                    sb.Append("\"code\": \"");
                    sb.Append(product.Code);
                    sb.Append("\", ");
                    sb.Append("\"color\": \"");
                    sb.Append(GetColorFor(product));
                    sb.Append("\", ");

                    if (product.Size != Product.SIZE_NOT_APPLICABLE)
                    {
                        sb.Append("\"size\": \"");
                        sb.Append(GetSizeFor(product));
                        sb.Append("\", ");
                    }

                    sb.Append("\"price\": ");
                    sb.Append(product.Price);
                    sb.Append(", ");
                    sb.Append("\"currency\": \"");
                    sb.Append(product.Currency);
                    sb.Append("\"}, ");
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


        private string GetSizeFor(Product product)
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

        private string GetColorFor(Product product)
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