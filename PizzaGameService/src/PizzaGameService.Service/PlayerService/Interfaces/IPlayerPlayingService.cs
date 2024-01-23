namespace PizzaGameService.Service.PlayerService.Interfaces;

public interface IPlayerPlayingService
{
    Task SetPlayerActive(int idPlayer, bool isPlaying);
}