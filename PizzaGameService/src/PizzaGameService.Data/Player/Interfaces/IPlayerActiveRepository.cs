namespace PizzaGameService.Data.Player.Interfaces;

public interface IPlayerActiveRepository
{
    Task SetPlayerActive(int id);
    
    Task SetPlayerInactive(int id);
}