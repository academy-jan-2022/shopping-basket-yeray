namespace ShoppingBasketKata;

public class ProductRepository : IProductRepository
{
    public Product Get(ProductID id) =>
        id.Value == 1
            ? new Product("The Hobbit", new Money(5), new ProductID(1))
            : new Product("Breaking Bad", new Money(7), new ProductID(145));
}
