using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Service.PlayerGameDataService.Interfaces;

public interface IPlayerDataService
{
    Task<PlayerGameData> GetPlayerData(int idPlayer);

    Task UpdatePlayerData(int idPlayer, PlayerGameData data);
}