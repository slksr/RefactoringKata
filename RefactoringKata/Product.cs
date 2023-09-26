namespace RefactoringKata;

public class Product
{
    public const int SizeNotApplicable = -1;

    public Product(string code, int color, int size, double price, string currency)
    {
        Code = code;
        Color = color;
        Size = size;
        Price = price;
        Currency = currency;
    }

    public string Code { get; }
    public int Color { get; }
    public int Size { get; }
    public double Price { get; }
    public string Currency { get; }
}