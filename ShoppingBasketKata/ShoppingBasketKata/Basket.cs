namespace ShoppingBasketKata;

public record Basket(UserID UserID, DateTime CreatedAt, BasketEntry[] ExpectedProducts)
{
    public Money TotalAmount => throw new NotImplementedException();
}
