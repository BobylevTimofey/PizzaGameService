namespace PizzaGameService.Service.Exceptions;

public class PlayerNotFoundException : Exception
{
    public PlayerNotFoundException(int idPlayer, Exception? exception = null) : base(BuildMessage(idPlayer), exception)
    {
    }

    private static string BuildMessage(int idPlayer)
    {
        return $"Player with id:{idPlayer} not found";
    }
}