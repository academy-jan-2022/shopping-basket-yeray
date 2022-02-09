namespace ShoppingBasketKata;

public class ShoppingBasketRepository : IShoppingBasketRepository
{
    public void Register(UserID userID, ProductID productID, int amount) { }

    public UserProductAmount[] GetFor(UserID userID) =>
        new[] { new UserProductAmount(new ProductID(1), userID, 5) };
}
