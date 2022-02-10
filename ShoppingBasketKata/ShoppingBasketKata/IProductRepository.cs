namespace ShoppingBasketKata;

public interface IProductRepository
{
    Product Get(ProductID id);
    void Upsert(Product hobbit);
}
