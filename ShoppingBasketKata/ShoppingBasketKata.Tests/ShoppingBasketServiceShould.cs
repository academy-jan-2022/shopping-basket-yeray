using System;
using Moq;
using Xunit;

namespace ShoppingBasketKata.Tests;

public class ShoppingBasketServiceShould
{
    private static readonly DateTime CreatedAt = new(2017, 01, 01);

    [Fact(DisplayName = "add an item to the user's basket")]
    public void Test1()
    {
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        var shoppingBasketRepositoryMock = new Mock<IShoppingBasketRepository>();
        var timeProviderMock = new Mock<ITimeProvider>();
        timeProviderMock.Setup(tp => tp.Now()).Returns(CreatedAt);
        var service = new ShoppingBasketService(
            shoppingBasketRepositoryMock.Object,
            Mock.Of<IProductRepository>(),
            timeProviderMock.Object
        );
        service.AddItem(userID, hobbitID, 3);
        shoppingBasketRepositoryMock.Verify(r => r.Register(userID, hobbitID, 3, CreatedAt), Times.Once);
    }

    [Fact(DisplayName = "add an item to the user's basket and get the basket")]
    public void Test2()
    {
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        var hobbit = new Product("The Hobbit", new Money(5), hobbitID);
        var shoppingBasketRepositoryMock = new Mock<IShoppingBasketRepository>();
        shoppingBasketRepositoryMock.Setup(sbr => sbr.GetFor(userID))
            .Returns(new[] { new UserProductAmount(hobbitID, userID, 7, CreatedAt) });
        var timeProviderMock = new Mock<ITimeProvider>();
        timeProviderMock.Setup(tp => tp.Now()).Returns(CreatedAt);
        var productRepositoryMock = new Mock<IProductRepository>();
        productRepositoryMock.Setup(pr => pr.Get(hobbitID)).Returns(hobbit);
        var service = new ShoppingBasketService(
            shoppingBasketRepositoryMock.Object,
            productRepositoryMock.Object,
            timeProviderMock.Object
        );
        var result = service.BasketFor(userID);
        Assert.Equal(userID, result.UserID);
        Assert.Equal(CreatedAt, result.CreatedAt);
        Assert.Equal(new[] { new BasketEntry(hobbit, 7) }, result.Products);
    }
}
