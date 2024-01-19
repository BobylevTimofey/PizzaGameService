namespace PizzaGameService.Data.Player.Interfaces;

public interface IPlayerActiveRepository
{
    public Task SetPlayerActive(int idPlayer, bool isActive);
    
    public Task<bool> GetPlayerActive(int idPlayer);
}