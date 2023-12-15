using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.PlayerData.Interfaces;

public interface IPlayerDataRepository
{
    Task SetPlayerData(int idPlayer);
    
    Task UpdatePlayerData(int idPlayer, PlayerGameData playerData);

    Task<PlayerGameData> GetPlayerData(int idPlayer);
}