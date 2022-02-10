namespace ShoppingBasketKata;

public class ShoppingBasketRepository : IShoppingBasketRepository
{
    private readonly Dictionary<UserID, Dictionary<ProductID, (int, DateTime)>> database = new();

    public void Register(UserID userID, ProductID productID, int amount, DateTime createdAt)
    {
        if (!database.ContainsKey(userID))
        {
            database[userID] = new Dictionary<ProductID, (int, DateTime)>();
        }

        if (!database[userID].ContainsKey(productID))
        {
            database[userID][productID] = (amount, createdAt);
            return;
        }

        var (currentAmount, originalCreatedAt) = database[userID][productID];
        database[userID][productID] = (amount + currentAmount, originalCreatedAt);
    }

    public UserProductAmount[] GetFor(UserID userID)
    {
        if (!database.ContainsKey(userID))
            return Array.Empty<UserProductAmount>();

        var result = new List<UserProductAmount>();
        foreach (var item in database[userID])
        {
            var (amount, createdAt) = item.Value;
            result.Add(new UserProductAmount(item.Key, userID, amount, createdAt));
        }

        return result.ToArray();
    }
}
