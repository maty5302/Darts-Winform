using Xunit;
using Domain;

namespace Domain.Tests
{
    public class HistoryScoreTests
    {
        [Fact]
        public void AddHistory_And_RedoLastScore_Works()
        {
            AverageScore.ClearAverage();
            HistoryScore.ClearHistory();

            AverageScore.AddAverage(0, 60);
            HistoryScore.AddHistory(0, "60");

            AverageScore.AddAverage(0, 20);
            HistoryScore.AddHistory(0, "20");

            var redo = HistoryScore.RedoLastScore(0);
            Assert.Equal("20", redo);
            Assert.False(HistoryScore.IsEmpty(0));

            var redo2 = HistoryScore.RedoLastScore(0);
            Assert.Equal("60", redo2);
            Assert.True(HistoryScore.IsEmpty(0));
        }

        [Fact]
        public void RedoLastScore_OnEmpty_ReturnsNull()
        {
            HistoryScore.ClearHistory();
            var r = HistoryScore.RedoLastScore(5);
            Assert.Null(r);
        }

        [Fact]
        public void RedoLastScore_RemoveLast()
        {
            AverageScore.ClearAverage();
            HistoryScore.ClearHistory();

            AverageScore.AddAverage(0, 100);
            HistoryScore.AddHistory(0, "100");

            AverageScore.AddAverage(0, 50);
            HistoryScore.AddHistory(0, "50");

            var redo = HistoryScore.RedoLastScore(0);
            Assert.Equal("50", redo);

            var redo2 = HistoryScore.RedoLastScore(0);
            Assert.Equal("100", redo2);

            var redo3 = HistoryScore.RedoLastScore(0);
            Assert.Null(redo3);
        }
    }
}
