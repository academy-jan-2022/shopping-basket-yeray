namespace ShoppingBasketKata;

public class ProductRepository : IProductRepository
{
    private readonly Dictionary<ProductID, ProductData> database = new();

    private record ProductData(string Name, Money Price);

    public Product Get(ProductID id)
    {
        var data = database[id];
        return new Product(data.Name, data.Price, id);
    }

    public void Upsert(Product product) =>
        database[product.ID] = new ProductData(product.Name, product.Price);
}
