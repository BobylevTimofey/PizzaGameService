namespace PizzaGameService.Service.Exceptions;

public class PlayerNotVerifyException: Exception
{
    public PlayerNotVerifyException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}