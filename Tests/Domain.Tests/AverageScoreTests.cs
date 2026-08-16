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
            var a = AverageScore.AddAverage(1, 30);
            Assert.Equal(20,a);
            AverageScore.RemoveLastAverage(1);
            a = AverageScore.GetAverageOfPlayer(1); // adds 0 -> average (10+0)/2 = 5
            Assert.Equal(10, a);
        }

        [Fact]
        public void ClearAverages_ReturnEmptyListOnPlayer()
        {
            AverageScore.ClearAverage();
            AverageScore.AddAverage(1, 10);
            AverageScore.AddAverage(1, 30);
            AverageScore.RemoveLastAverage(1);
            
            var a = AverageScore.AddAverage(1, 0); // adds 0 -> average (10+0)/2 = 5
            Assert.Equal(5, a);
            
            AverageScore.ClearAverage();
            Assert.Equal(0, AverageScore.GetAverageOfPlayer(1));
        }
        
        [Fact]
        public void GetAverage_ReturnZeroOnInvalidPlayer()
        {
            Assert.Equal(0, AverageScore.GetAverageOfPlayer(-1));
        }
    }
}
