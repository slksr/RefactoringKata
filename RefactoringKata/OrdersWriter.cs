using System.Text;

namespace RefactoringKata;

public class OrdersWriter
{
    private readonly Orders _orders;

    public OrdersWriter(Orders orders)
    {
        _orders = orders;
    }

    public string GetContents()
    {
        StringBuilder sb = SetOrderWriter();

        for (var i = 0; i < _orders.GetOrdersCount(); i++)
        {
            var order = _orders.GetOrder(i);
            AddOrder(sb, order.GetOrderId());

            for (var j = 0; j < order.GetProductsCount(); j++)
            {
                var product = order.GetProduct(j);
                AddProductToOrder(sb, product);
            }

            if (order.GetProductsCount() > 0)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            CloseOrder(sb);
        }

        if (_orders.GetOrdersCount() > 0)
        {
            sb.Remove(sb.Length - 2, 2);
        }

        return CloseOrderWriter(sb);
    }

    private void AddProductToOrder(StringBuilder sb, Product product)
    {
        sb.Append("{");
        sb.Append("\"code\": \"");
        sb.Append(product.Code);
        sb.Append("\", ");
        sb.Append("\"color\": \"");
        sb.Append(GetColorFor(product));
        sb.Append("\", ");

        if (product.Size != Product.SizeNotApplicable)
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

    private void AddOrder(StringBuilder sb, int orderId)
    {
        sb.Append("{");
        sb.Append("\"id\": ");
        sb.Append(orderId);
        sb.Append(", ");
        sb.Append("\"products\": [");
    }

    private void CloseOrder(StringBuilder sb)
    {
        sb.Append("]");
        sb.Append("}, ");
    }


    private StringBuilder SetOrderWriter()
    {
        return new StringBuilder("{\"orders\": [");
    }

    private string CloseOrderWriter(StringBuilder sb)
    {
        return sb.Append("]}").ToString();
    }


    private string GetSizeFor(Product product)
    {
        return product.Size switch
        {
            1 => "XS",
            2 => "S",
            3 => "M",
            4 => "L",
            5 => "XL",
            6 => "XXL",
            _ => "Invalid Size"
        };
    }

    private string GetColorFor(Product product)
    {
        return product switch
        {
            { Color: 1 } => "blue",
            { Color: 2 } => "red",
            { Color: 3 } => "yellow",
            _ => "no color"
        };
    }
}