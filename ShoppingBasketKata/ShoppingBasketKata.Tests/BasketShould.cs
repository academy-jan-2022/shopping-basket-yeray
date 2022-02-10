using System;
using Xunit;

namespace ShoppingBasketKata.Tests;

public class BasketShould
{
    private static readonly Product OneCentProduct =
        new("One Cent, forty nine times less than the rapper", new Money(1), new ProductID(3));

    [Fact(DisplayName = "calculate the total for one product")]
    public void Test1()
    {
        var basket = new Basket(
            new UserID(1),
            DateTime.Now,
            new[] { new BasketEntry(OneCentProduct, 1) }
        );
        Assert.Equal(new Money(1), basket.TotalAmount);
    }

    [Fact(DisplayName = "calculate the total for one product three times")]
    public void Test2()
    {
        var basket = new Basket(
            new UserID(1),
            DateTime.Now,
            new[] { new BasketEntry(OneCentProduct, 3) }
        );
        Assert.Equal(new Money(3), basket.TotalAmount);
    }
}
