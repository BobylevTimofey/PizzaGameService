namespace PizzaGameService.Service.Exceptions;

public class PlayerNotFoundException : Exception
{
    public PlayerNotFoundException(string identification, Exception? exception = null) : base(BuildMessage(identification), exception)
    {
    }

    private static string BuildMessage(string identification)
    {
        return $"Player with identification:{identification} not found";
    }
}