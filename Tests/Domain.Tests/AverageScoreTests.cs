using Xunit;
using Domain;

namespace Domain.Tests
{
    public class AverageScoreTests
    {
        [Fact]
        public void AddAverage_ReturnsCorrectAverage()
        {
            AverageScore.ClearAverage();
            var a = AverageScore.AddAverage(0, 40);
            Assert.Equal(40, a);
            a = AverageScore.AddAverage(0, 20);
            Assert.Equal(30, a);
        }

        [Fact]
        public void RemoveLastAverage_RemovesLast()
        {
            AverageScore.ClearAverage();
            AverageScore.AddAverage(1, 10);
            AverageScore.AddAverage(1, 30);
            AverageScore.RemoveLastAverage(1);
            // now list contains only 10
            var a = AverageScore.AddAverage(1, 0); // adds 0 -> average (10+0)/2 = 5
            Assert.Equal(5, a);
        }
    }
}
