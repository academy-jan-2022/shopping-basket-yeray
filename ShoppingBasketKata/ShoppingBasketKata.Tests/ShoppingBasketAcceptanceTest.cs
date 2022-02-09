using System;
using Xunit;

namespace ShoppingBasketKata.Tests;

public class ShoppingBasketAcceptanceTest
{
    /*
Given I add 2 units of "The Hobbit" to my shopping basket
And I add 5 units of "Breaking Bad"
When I check the content of my shopping basket
Then it should contain the following infomation:
- Creation date (of the shopping basket)
- 2 x The Hobbit   // 2 x 5.00 = £10.00
- 5 x Breaking Bad // 5 x 7.00 = £35.00
- Total: £45.00
     */

    [Fact(DisplayName = "follows the acceptance scenario")]
    public void Test1()
    {
        var userID = new UserID(1);
        var hobbitID = new ProductID(1);
        var hobbit = new Product("The Hobbit", new Money(5), hobbitID);
        var breakingBadID = new ProductID(145);
        var breakingBad = new Product("Breaking Bad", new Money(7), breakingBadID);
        var service = new ShoppingBasketService();
        service.AddItem(userID, hobbitID, 2);
        service.AddItem(userID, breakingBadID, 5);
        var basket = service.BasketFor(userID);

        var expectedProducts = new BasketEntry[]
        {
            new(hobbit, 2),
            new(breakingBad, 5)
        };

        var expectedBasket = new Basket(userID, new DateTime(2017, 1, 1), expectedProducts);

        Assert.Equal(expectedBasket, basket);
        Assert.Equal(new Money(45), basket.TotalAmount);
    }
}
