namespace PizzaGameService.Service.Exceptions;

public class PlayerAlreadyPlayingException : Exception
{
    public PlayerAlreadyPlayingException(string message, Exception? exception = null) : base(message, exception)
    {
    }
}