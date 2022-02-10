namespace ShoppingBasketKata;

public class ShoppingBasketRepository : IShoppingBasketRepository
{
    private class UserBasket
    {
        public DateTime CreatedAt { get; }
        public Dictionary<ProductID, int> Amounts { get; } = new();

        public UserBasket(DateTime createdAt) =>
            CreatedAt = createdAt;

        public void Add(ProductID id, int amount)
        {
            if (!Amounts.ContainsKey(id))
                Amounts[id] = 0;
            Amounts[id] += amount;
        }
    }

    private readonly Dictionary<UserID, UserBasket> database = new();

    public void Register(UserID userID, ProductID productID, int amount, DateTime createdAt)
    {
        if (!database.ContainsKey(userID))
        {
            database[userID] = new UserBasket(createdAt);
        }
        database[userID].Add(productID, amount);
    }

    public UserProductAmount[] GetFor(UserID userID)
    {
        var result = new List<UserProductAmount>();
        var createdAt = database[userID].CreatedAt;
        foreach (var item in database[userID].Amounts)
        {
            var (productID, amount) = item;
            result.Add(new UserProductAmount(productID, userID, amount, createdAt));
        }

        return result.ToArray();
    }
}
