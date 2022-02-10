namespace ShoppingBasketKata;

public class TimeProvider : ITimeProvider
{
    public DateTime Today() =>
        DateTime.Now.Date;
}
