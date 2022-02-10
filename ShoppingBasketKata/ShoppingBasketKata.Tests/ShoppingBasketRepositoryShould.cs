using System;
using Xunit;

namespace ShoppingBasketKata.Tests;

public class ShoppingBasketRepositoryShould
{
    private static readonly DateTime CreatedAt = new(2019, 08, 19);

    [Fact(DisplayName = "register something being added to the basket")]
    public void Test1()
    {
        IShoppingBasketRepository repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var hobbitID = new ProductID(7);
        repository.Register(userID, hobbitID, 5, CreatedAt);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hobbitID, userID, 5, CreatedAt) }, result);
    }

    [Fact(DisplayName = "register something being added twice to the basket")]
    public void Test4()
    {
        IShoppingBasketRepository repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        repository.Register(userID, hobbitID, 5, CreatedAt);
        repository.Register(userID, hobbitID, 5, CreatedAt);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hobbitID, userID, 10, CreatedAt) }, result);
    }

    [Fact(DisplayName = "registers something else being added to the basket")]
    public void Test2()
    {
        IShoppingBasketRepository repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var hitchickersGuideToTheGalaxyID = new ProductID(42);
        repository.Register(userID, hitchickersGuideToTheGalaxyID, 3, CreatedAt);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hitchickersGuideToTheGalaxyID, userID, 3, CreatedAt) }, result);
    }

    [Fact(DisplayName = "registers something added to the basket for another user")]
    public void Test3()
    {
        IShoppingBasketRepository repository = new ShoppingBasketRepository();
        var userID = new UserID(1);
        var anotherUserID = new UserID(2);
        var hitchickersGuideToTheGalaxyID = new ProductID(42);
        repository.Register(userID, hitchickersGuideToTheGalaxyID, 3, CreatedAt);
        repository.Register(anotherUserID, hitchickersGuideToTheGalaxyID, 6, CreatedAt);
        var result = repository.GetFor(userID);
        Assert.Equal(new [] { new UserProductAmount(hitchickersGuideToTheGalaxyID, userID, 3, CreatedAt) }, result);
    }
}
