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
    }

    [Fact(DisplayName = "registers something else being added to the basket")]
    public void Test2()
    {
        var repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var hitchickersGuideToTheGalaxyID = new ProductID(42);
        repository.Register(userID, hitchickersGuideToTheGalaxyID, 3);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hitchickersGuideToTheGalaxyID, userID, 3) }, result);
    }

    [Fact(DisplayName = "registers something added to the basket for another user")]
    public void Test3()
    {
        var repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var anotherUserID = new UserID(2);
        var hitchickersGuideToTheGalaxyID = new ProductID(42);
        repository.Register(userID, hitchickersGuideToTheGalaxyID, 3);
        repository.Register(anotherUserID, hitchickersGuideToTheGalaxyID, 6);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hitchickersGuideToTheGalaxyID, userID, 3) }, result);
    }
}
