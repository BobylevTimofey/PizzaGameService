namespace PizzaGameService.Data.PlayerData.Interfaces;

public interface IPlayerActiveRepository
{
    Task SetPlayerActive(int id);
    
    Task SetPlayerInactive(int id);
}