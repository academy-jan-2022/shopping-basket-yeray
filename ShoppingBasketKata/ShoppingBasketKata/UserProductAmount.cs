namespace ShoppingBasketKata;

public record UserProductAmount(ProductID ProductID, UserID UserID, int Amount, DateTime CreatedAt);
