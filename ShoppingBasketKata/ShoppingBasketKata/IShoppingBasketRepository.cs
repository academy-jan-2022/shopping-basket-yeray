namespace ShoppingBasketKata;

public interface IShoppingBasketRepository
{
    void Register(UserID userID, ProductID productID, int amount);
}
