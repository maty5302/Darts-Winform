using Domain.Models;

namespace Domain.Interfaces
{
    public interface IDartsRepository
    {
       Task<List<PlayerDto>> GetAllPlayersAsync();
       Task<PlayerDto?> GetPlayerByIdAsync(long playerId);
       Task<PlayerDto?> CreatePlayerAsync(string playerName);
       Task DeletePlayerAsync(long playerId);
       Task RenamePlayerAsync(long playerId, string newName);
       
       Task<PlayerStatsDto?> GetStatsForYearAsync(long playerId, int year);
       Task UpdateStatsAsync(PlayerStatsDto statsDto); 
       Task<List<int>> GetAvailableYearsAsync(long playerId);
    }
}