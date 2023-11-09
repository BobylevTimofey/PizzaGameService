namespace PizzaGameService.Service.Exceptions;

public class PlayerAlreadyRegisteredException : Exception
{
    public PlayerAlreadyRegisteredException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}