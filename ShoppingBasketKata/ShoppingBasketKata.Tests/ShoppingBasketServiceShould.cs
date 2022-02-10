using System;
using Moq;
using Xunit;

namespace ShoppingBasketKata.Tests;

public class ShoppingBasketServiceShould
{
    [Fact(DisplayName = "add an item to the user's basket")]
    public void Test1()
    {
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        var shoppingBasketRepositoryMock = new Mock<IShoppingBasketRepository>();
        var service = new ShoppingBasketService(
            shoppingBasketRepositoryMock.Object,
            Mock.Of<IProductRepository>(),
            Mock.Of<ITimeProvider>()
        );
        service.AddItem(userID, hobbitID, 3);
        shoppingBasketRepositoryMock.Verify(r => r.Register(userID, hobbitID, 3), Times.Once);
    }

    [Fact(DisplayName = "add an item to the user's basket and get the basket")]
    public void Test2()
    {
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        var hobbit = new Product("The Hobbit", new Money(5), hobbitID);
        var shoppingBasketRepositoryMock = new Mock<IShoppingBasketRepository>();
        var timeProviderMock = new Mock<ITimeProvider>();
        var createdAt = new DateTime(2017, 01, 01);
        timeProviderMock.Setup(tp => tp.Now()).Returns(createdAt);
        var productRepositoryMock = new Mock<IProductRepository>();
        productRepositoryMock.Setup(pr => pr.Get(hobbitID)).Returns(hobbit);
        var service = new ShoppingBasketService(
            shoppingBasketRepositoryMock.Object,
            productRepositoryMock.Object,
            timeProviderMock.Object
        );
        var result = service.BasketFor(userID);
        var expectedBasket = new Basket(
            userID,
            createdAt,
            new[] { new BasketEntry(hobbit, 7) }
        );
        Assert.Equal(expectedBasket, result);
    }
}
