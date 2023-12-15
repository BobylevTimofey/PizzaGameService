using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.Player.Models;

namespace PizzaGameService.Tests.PlayerService.Mock;

public class PlayerRepositoryMock : IPlayerRepository, IPlayerActiveRepository
{
    private List<(int, PlayerSetParameters, bool)> _data = new();
    private int _id;

    public Task SetPlayer(PlayerSetParameters playerSetParameters)
    {
        var newId = _id++;
        var newPlayer = (newId, playerSetParameters, false);

        _data.Add(newPlayer);

        return Task.FromResult(newId);
    }

    public Task<Player> GetPlayer(int idPlayer)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<RegisteredPlayer>> GetAllPlayers()
    {
        var result = _data.Select(player => new RegisteredPlayer
        {
            Id = player.Item1,
            Login = player.Item2.Login,
            Password = player.Item2.Password,
            Email = player.Item2.Email,
            IsPlaying = player.Item3
        }).ToList();

        return Task.FromResult<IReadOnlyList<RegisteredPlayer>>(result);
    }

    public Task SetPlayerActive(int id)
    {
        var a = _data.FirstOrDefault(player => player.Item1 == id);

        _data.Remove(a);
        a.Item3 = true;
        _data.Add(a);

        return Task.CompletedTask;
    }

    public Task SetPlayerInactive(int id)
    {
        var a = _data.FirstOrDefault(player => player.Item1 == id);

        _data.Remove(a);
        a.Item3 = false;
        _data.Add(a);

        return Task.CompletedTask;
    }
}