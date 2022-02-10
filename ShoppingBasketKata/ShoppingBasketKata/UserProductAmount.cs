namespace ShoppingBasketKata;

public record UserProductAmount(ProductID ProductID, UserID UserID, int Count, DateTime CreatedAt);
