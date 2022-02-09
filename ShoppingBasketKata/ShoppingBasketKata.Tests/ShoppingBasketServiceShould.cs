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
        var shoppingBasketRepository = new Mock<IShoppingBasketRepository>();
        var service = new ShoppingBasketService(shoppingBasketRepository.Object);
        service.AddItem(userID, hobbitID, 3);
        shoppingBasketRepository.Verify(r => r.Register(userID, hobbitID, 3));
    }
}
