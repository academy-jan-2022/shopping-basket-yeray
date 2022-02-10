namespace ShoppingBasketKata;

public record Basket(UserID UserID, DateTime CreatedAt, BasketEntry[] ExpectedProducts)
{
    public Money TotalAmount
    {
        get
        {
            var result = 0;
            foreach (var expectedProduct in ExpectedProducts)
                result += expectedProduct.Amount * expectedProduct.Product.Price.Amount;

            return new Money(result);
        }
    }
}
