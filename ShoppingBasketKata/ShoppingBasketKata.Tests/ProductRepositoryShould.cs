using Xunit;

namespace ShoppingBasketKata.Tests;

public class ProductRepositoryShould
{
    [Fact(DisplayName = "add a product")]
    public void Test1()
    {
        IProductRepository repo = new ProductRepository();
        var breakingBadID = new ProductID(145);
        var breakingBad = new Product("Breaking Bad", new Money(7), breakingBadID);
        repo.Upsert(breakingBad);
        var result = repo.Get(breakingBadID);
        Assert.Equal(breakingBad, result);
    }
}
