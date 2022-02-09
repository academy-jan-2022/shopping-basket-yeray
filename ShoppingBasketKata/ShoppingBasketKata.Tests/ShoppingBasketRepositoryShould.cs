using Xunit;

namespace ShoppingBasketKata.Tests;

public class ShoppingBasketRepositoryShould
{
    [Fact(DisplayName = "register something being added to the basket")]
    public void Test1()
    {
        var repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        repository.Register(userID, hobbitID, 5);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hobbitID, userID, 5) }, result);
    }g
}
