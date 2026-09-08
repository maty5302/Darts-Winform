using DesktopUI.ViewModels;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Integration.Tests
{
    public class GameFlowIntegrationTests
    {
        private DartsRepository CreateInMemoryRepo()
        {
            var options = new DbContextOptionsBuilder<DartsDbContext>()
                .UseInMemoryDatabase(databaseName: $"Integration_{Guid.NewGuid()}")
                .Options;
            return new DartsRepository(options);
        }

        [Fact]
        public void SubmitThrow_ShouldUpdateDomainStats_And_ViewModelProperties()
        {
            var repo = CreateInMemoryRepo();
            
            var playerVm = new PlayerViewModel(repo)
            {
                Score = 501,
                CurrentThrow = "60" 
            };

            playerVm.SubmitThrow();

            Assert.Equal(441, playerVm.Score); 
            Assert.Equal(60.0, playerVm.Average); 
            Assert.Equal(string.Empty, playerVm.CurrentThrow);

            Assert.False(playerVm.MatchStats.IsEmpty);
            Assert.Equal(60.0, playerVm.MatchStats.CurrentAverage);
        }

        [Fact]
        public async Task MainViewModel_ShouldLoadPlayersFromDatabase()
        {
            var repo = CreateInMemoryRepo();
            await repo.CreatePlayerAsync("Matěj");
            await repo.CreatePlayerAsync("Soupeř");

            var mainVm = new MainViewModel(repo);

            var dbPlayers = await mainVm.GetDatabasePlayersAsync();

            Assert.NotNull(dbPlayers);
            Assert.Equal(2, dbPlayers.Count);
            Assert.Contains(dbPlayers, p => p.PlayerName == "Matěj");
        }
        
        [Fact]
        public void UndoThrow_ShouldCompletelyRestorePreviousState()
        {
            var repo = CreateInMemoryRepo();
            
            var playerVm = new PlayerViewModel(repo) { Score = 100 };
            playerVm.CurrentThrow = "40";
            playerVm.SubmitThrow();
            
            Assert.Equal(60, playerVm.Score);
            Assert.Equal(40.0, playerVm.Average);

            playerVm.UndoThrow();

            Assert.Equal(100, playerVm.Score); 
            Assert.Equal(0.0, playerVm.Average); 
            Assert.True(playerVm.MatchStats.IsEmpty); 
        }
        
        [Fact]
        public void SubmitThrow_WinningThrow_ShouldFinishPlayerAndLockUI()
        {
            var repo = CreateInMemoryRepo();
            
            var playerVm = new PlayerViewModel(repo) { Score = 40 };

            playerVm.CurrentThrow = "40";
            playerVm.SubmitThrow();

            Assert.Equal(0, playerVm.Score); 
            Assert.True(playerVm.HasFinished);
            Assert.False(playerVm.IsEnabled); 
            
            Assert.Contains("místo", playerVm.DisplayText); 
        }
        
        [Fact]
        public void StartGame_ShouldGenerateCorrectNumberOfPlayersAndSetFirstActive()
        {
            var repo = CreateInMemoryRepo();
            
            var mainVm = new MainViewModel(repo)
            {
                PlayerCount = 3, 
                Score = 301     
            };

            mainVm.StartGameCommand.Execute(null);

            Assert.False(mainVm.IsDuelMode); 
            Assert.Equal(3, mainVm.Players.Count); 
            
            Assert.All(mainVm.Players, p => Assert.Equal(301, p.Score));
            
            Assert.True(mainVm.Players[0].IsActive);
            Assert.False(mainVm.Players[1].IsActive);
            Assert.False(mainVm.Players[2].IsActive);
        }
    }
}