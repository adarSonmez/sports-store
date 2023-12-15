namespace SportsStore.Models;

// Represents a shopping cart containing a list of cart lines.
public class Cart
{
    public List<CartLine> Lines { get; set; } = new();

    public virtual void AddItem(Product product, int quantity)
    {
        var line = Lines.FirstOrDefault(p => p.Product.ProductId == product.ProductId);

        if (line == null)
            Lines.Add(new CartLine
            {
                Product = product,
                Quantity = quantity
            });
        else
            line.Quantity += quantity;
    }

    public virtual void RemoveLine(Product product)
    {
        Lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
    }

    public decimal ComputeTotalValue()
    {
        return Lines.Sum(e => e.Product.Price * e.Quantity);
    }
    
    public virtual void Clear()
    {
        Lines.Clear();
    }
}

// Represents a single line in the shopping cart, associating a product with its quantity.
public class CartLine
{
    public int CartLineId { get; set; }

    public Product Product { get; set; } = new();

    public int Quantity { get; set; }
}