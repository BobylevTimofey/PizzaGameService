using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayerData.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerGameDataService.Interfaces;

namespace PizzaGameService.Service.PlayerGameDataService.Implementations;

public class PlayerDataService : IPlayerDataService
{
    private readonly IPlayerDataRepository _playerDataRepository;
    private readonly IPlayerRepository _playerRepository;

    public PlayerDataService(IPlayerDataRepository playerDataRepository, IPlayerRepository playerRepository)
    {
        _playerDataRepository = playerDataRepository;
        _playerRepository = playerRepository;
    }

    public async Task<PlayerGameData> GetPlayerData(int idPlayer)
    {
        try
        {
            return await _playerDataRepository.GetPlayerData(idPlayer);
        }
        catch (Exception)
        {
            throw new PlayerNotFoundException(idPlayer.ToString());
        }
    }

    public async Task UpdatePlayerData(int idPlayer, PlayerGameData data)
    {
        try
        {
            await _playerDataRepository.UpdatePlayerData(idPlayer, data);
            await _playerRepository.UpdatePlayerRating(idPlayer, data.Rating);
        }
        catch (Exception)
        {
            throw new PlayerNotFoundException(idPlayer.ToString());
        }
    }
}