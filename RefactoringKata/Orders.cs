namespace RefactoringKata;

public class Orders
{
    private readonly List<Order> _orders = new();

    public void AddOrder(Order order)
    {
        _orders.Add(order);
    }

    public int GetOrdersCount()
    {
        return _orders.Count;
    }

    public Order GetOrder(int i)
    {
        return _orders[i];
    }
}