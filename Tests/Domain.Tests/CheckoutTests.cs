using Xunit;
using Domain;

namespace Domain.Tests
{
    public class CheckoutTests
    {
        [Theory]
        [InlineData(170, "T20 T20 Bull")]
        [InlineData(160, "T20 T20 D20")]
        [InlineData(169, "")]
        [InlineData(171, ".")]
        [InlineData(100, "T20 D20")]
        [InlineData(2, "D1")]
        [InlineData(0, ".")]
        public void Checkout_ReturnsExpected(int score, string expected)
        {
            var result = Checkout.checkout(score);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CheckoutReturnsEmptyOnMoreLike180()
        {
            var res = Checkout.checkout(254);
            Assert.Empty(res);
        }
    }
}
