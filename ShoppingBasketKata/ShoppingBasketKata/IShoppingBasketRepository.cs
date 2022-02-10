namespace ShoppingBasketKata;

public interface IShoppingBasketRepository
{
    void Register(UserID userID, ProductID productID, int amount, DateTime createdAt);
    UserProductAmount[] GetFor(UserID userID);
    DateTime GetCreationDate(UserID userId);
}
