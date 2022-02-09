namespace ShoppingBasketKata;

public class ShoppingBasketRepository : IShoppingBasketRepository
{
    private readonly Dictionary<UserID, Dictionary<ProductID, int>> database = new();

    public void Register(UserID userID, ProductID productID, int amount)
    {
        if (!database.ContainsKey(userID))
        {
            database[userID] = new Dictionary<ProductID, int>();
        }

        if (!database[userID].ContainsKey(productID))
        {
            database[userID][productID] = amount;
            return;
        }

        database[userID][productID] += amount;
    }

    public UserProductAmount[] GetFor(UserID userID)
    {
        if (!database.ContainsKey(userID))
            return Array.Empty<UserProductAmount>();

        var result = new List<UserProductAmount>();
        foreach (var item in database[userID])
        {
            result.Add(new UserProductAmount(item.Key, userID, item.Value));
        }

        return result.ToArray();
    }
}
