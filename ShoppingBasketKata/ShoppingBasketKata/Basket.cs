namespace ShoppingBasketKata;

public record Basket(UserID UserID, DateTime CreatedAt, BasketEntry[] Products)
{
    public Money TotalAmount
    {
        get
        {
            var result = 0;
            foreach (var expectedProduct in Products)
                result += expectedProduct.Amount * expectedProduct.Product.Price.Amount;

            return new Money(result);
        }
    }
}
