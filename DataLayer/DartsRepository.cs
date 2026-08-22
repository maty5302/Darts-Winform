using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using Domain.Interfaces;
using Domain.Models;   
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer;

public class DartsRepository : IDartsRepository
{
    public DartsRepository()
    {
        using var context = new DartsDbContext();
        context.Database.EnsureCreated();
    }
    
    public async Task<List<PlayerDto>> GetAllPlayersAsync()
    {
        await using var context = new DartsDbContext();
        
        return await context.Players
            .Select(p => new PlayerDto 
            { 
                Id = p.Id, 
                PlayerName = p.PlayerName 
            })
            .ToListAsync();
    }
    
    public async Task<PlayerDto?> GetPlayerByIdAsync(long playerId)
    {
        await using var context = new DartsDbContext();
        var player = await context.Players.FirstOrDefaultAsync(p => p.Id == playerId);
        
        if (player == null) return null;
        
        return new PlayerDto 
        { 
            Id = player.Id, 
            PlayerName = player.PlayerName 
        };
    }
    
    public async Task<PlayerDto?> CreatePlayerAsync(string playerName)
    {
        await using var context = new DartsDbContext();
        
        if (await context.Players.AnyAsync(p => p.PlayerName == playerName))
            return null;
            
        var player = new Player { PlayerName = playerName };
        context.Players.Add(player);
        await context.SaveChangesAsync();
        
        return new PlayerDto 
        { 
            Id = player.Id, 
            PlayerName = player.PlayerName 
        };
    }
    
    public async Task DeletePlayerAsync(long playerId)
    {
        await using var context = new DartsDbContext();
        var player = await context.Players.FindAsync(playerId);
        
        if (player != null)
        {
            context.Players.Remove(player);
            await context.SaveChangesAsync();
        }
    }
    
    public async Task RenamePlayerAsync(long playerId, string newName)
    {
        await using var context = new DartsDbContext();
        var player = await context.Players.FindAsync(playerId);
        
        if (player != null)
        {
            player.PlayerName = newName;
            await context.SaveChangesAsync();
        }
    }
    
    /// <summary>
    /// Methods for statistics
    /// </summary>
    /// 
    public async Task<PlayerStatsDto?> GetStatsForYearAsync(long playerId, int year)
    {
        await using var context = new DartsDbContext();
        var stats = await context.YearlyStatistics
            .FirstOrDefaultAsync(s => s.PlayerId == playerId && s.Year == year);

        if (stats == null) return null;

        return new PlayerStatsDto
        {
            PlayerId = stats.PlayerId,
            Year = stats.Year,
            Wins = stats.Wins,
            Average = stats.Average,
            HighestOut = stats.HighestOut,
            Sixty = stats.Sixty,
            Hundred = stats.Hundred,
            Hundred20 = stats.Hundred20,
            Hundred80 = stats.Hundred80,
            AllWins = stats.AllWins,
            OldHighestOut = stats.OldHighestOut,
            AllSixty = stats.AllSixty,
            AllHundred = stats.AllHundred,
            AllHundred20 = stats.AllHundred20,
            AllHundred80 = stats.AllHundred80
        };
    }
    
    public async Task UpdateStatsAsync(PlayerStatsDto statsDto)
    {
        await using var context = new DartsDbContext();
    
        var existing = await context.YearlyStatistics
            .FirstOrDefaultAsync(s => s.PlayerId == statsDto.PlayerId && s.Year == statsDto.Year);

        if (existing == null)
        {
            var newStats = new YearlyStatistic
            {
                PlayerId = statsDto.PlayerId, 
                Year = statsDto.Year,
                Wins = statsDto.Wins,
                Average = statsDto.Average,
                HighestOut = statsDto.HighestOut,
                Sixty = statsDto.Sixty,
                Hundred = statsDto.Hundred,
                Hundred20 = statsDto.Hundred20,
                Hundred80 = statsDto.Hundred80,
                AllWins = statsDto.AllWins,
                OldHighestOut = statsDto.OldHighestOut,
                AllSixty = statsDto.AllSixty,
                AllHundred = statsDto.AllHundred,
                AllHundred20 = statsDto.AllHundred20,
                AllHundred80 = statsDto.AllHundred80
            };
            context.YearlyStatistics.Add(newStats);
        }
        else
        {
            existing.Wins = statsDto.Wins;
            existing.Average = statsDto.Average;
            existing.HighestOut = statsDto.HighestOut;
            existing.Sixty = statsDto.Sixty;
            existing.Hundred = statsDto.Hundred;
            existing.Hundred20 = statsDto.Hundred20;
            existing.Hundred80 = statsDto.Hundred80;
            existing.AllWins = statsDto.AllWins;
            existing.OldHighestOut = statsDto.OldHighestOut;
            existing.AllSixty = statsDto.AllSixty;
            existing.AllHundred = statsDto.AllHundred;
            existing.AllHundred20 = statsDto.AllHundred20;
            existing.AllHundred80 = statsDto.AllHundred80;
        }

        await context.SaveChangesAsync();
    }
    
    public async Task<PlayerStatsDto?> GetAllYearsStatsAsync(long playerId)
    {
        using var context = new DartsDbContext();
    
        var latestStats = await context.YearlyStatistics
            .Where(s => s.PlayerId == playerId)
            .OrderByDescending(s => s.Year)
            .FirstOrDefaultAsync();

        if (latestStats == null) 
            return null;

        return new PlayerStatsDto
        {
            PlayerId = latestStats.PlayerId,
            AllWins = latestStats.AllWins,
            OldHighestOut = latestStats.OldHighestOut, 
            AllSixty = latestStats.AllSixty,
            AllHundred = latestStats.AllHundred,
            AllHundred20 = latestStats.AllHundred20,
            AllHundred80 = latestStats.AllHundred80
        };
    }
}