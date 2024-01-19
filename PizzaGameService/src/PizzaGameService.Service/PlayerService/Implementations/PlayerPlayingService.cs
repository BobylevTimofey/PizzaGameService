using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerService.Interfaces;

namespace PizzaGameService.Service.PlayerService.Implementations;

public class PlayerPlayingService : IPlayerPlayingService
{
    private readonly IPlayerActiveRepository _playerActiveRepository;

    public PlayerPlayingService(IPlayerActiveRepository playerActiveRepository)
    {
        _playerActiveRepository = playerActiveRepository;
    }

    public async Task SetPlayerActive(int idPlayer, bool isPlaying)
    {
        var isPlayingNow = await _playerActiveRepository.GetPlayerActive(idPlayer);

        if (isPlayingNow && isPlaying)
        {
            throw new PlayerAlreadyPlayingException($"Player with id :{idPlayer} already playing");
        }

        await _playerActiveRepository.SetPlayerActive(idPlayer, isPlaying);
    }
}