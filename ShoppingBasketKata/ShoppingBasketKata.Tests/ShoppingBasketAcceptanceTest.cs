using Xunit;

namespace ShoppingBasketKata.Tests;

public class ShoppingBasketAcceptanceTest
{
    /*
Given I add 2 units of "The Hobbit" to my shopping basket
And I add 5 units of "Breaking Bad"
When I check the content of my shopping basket
Then it should contain the following infomation:
- Creation date (of the shopping basket)
- 2 x The Hobbit   // 2 x 5.00 = £10.00
- 5 x Breaking Bad // 5 x 7.00 = £35.00
- Total: £45.00
     */

    [Fact(DisplayName = "follows the acceptance scenario")]
    public void Test1()
    {

    }
}
