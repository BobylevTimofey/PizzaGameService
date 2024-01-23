using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayerData.Models;
using PizzaGameService.Data.PlayersRating.Interfaces;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerGameDataService.Interfaces;

namespace PizzaGameService.Service.PlayerGameDataService.Implementations;

public class PlayerDataService : IPlayerDataService
{
    private readonly IPlayerDataRepository _playerDataRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayersRatingRepository _ratingRepository;

    public PlayerDataService(IPlayerDataRepository playerDataRepository, IPlayerRepository playerRepository,
        IPlayersRatingRepository ratingRepository)
    {
        _playerDataRepository = playerDataRepository;
        _playerRepository = playerRepository;
        _ratingRepository = ratingRepository;
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
            var playerInTop = await _ratingRepository.GetPlayerPlaceInTop(idPlayer);

            if (playerInTop is not null && playerInTop.Rating < data.Rating)
                await _playerRepository.UpdatePlayerBestRating(idPlayer, data.Rating);
        }
        catch (Exception)
        {
            throw new PlayerNotFoundException(idPlayer.ToString());
        }
    }
}