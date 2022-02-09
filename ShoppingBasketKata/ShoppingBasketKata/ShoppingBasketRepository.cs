namespace ShoppingBasketKata;

public class ShoppingBasketRepository : IShoppingBasketRepository
{
    private readonly List<UserProductAmount> database = new();

    public void Register(UserID userID, ProductID productID, int amount) =>
        database.Add(new UserProductAmount(productID, userID, amount));

    public UserProductAmount[] GetFor(UserID userID) =>
        database.ToArray();
}
