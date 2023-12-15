using PizzaGameService.Data.Player.Interfaces;
using PizzaGameService.Data.Player.Models;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.PlayerService.Requests;

namespace PizzaGameService.Service.PlayerService.Implementations;

public class PlayerAuthorizationService : IPlayerAuthorizationService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayerActiveRepository _playerActiveRepository;
    private readonly IPlayerDataRepository _playerDataRepository;

    public PlayerAuthorizationService(IPlayerRepository playerRepository,
        IPlayerActiveRepository playerActiveRepository, IPlayerDataRepository playerDataRepository)
    {
        _playerRepository = playerRepository;
        _playerActiveRepository = playerActiveRepository;
        _playerDataRepository = playerDataRepository;
    }

    public async Task<int> SingIn(PlayerAuthorizationRequest player)
    {
        var players = await _playerRepository.GetAllPlayers();

        var registeredPlayer = players.FirstOrDefault(registeredPlayer =>
            registeredPlayer.Login == player.Login &&
            BCrypt.Net.BCrypt.Verify(player.Password, registeredPlayer.Password));

        if (registeredPlayer is null)
        {
            throw new PlayerNotVerifyException("Incorrect login or password");
        }

        if (registeredPlayer.IsPlaying)
        {
            throw new PlayerAlreadyPlayingException("Player already playing");
        }

        var playerId = registeredPlayer.Id;

        /*await _playerActiveRepository.SetPlayerActive(playerId);*/

        return playerId;
    }

    public async Task SignUp(PlayerRegistrationRequest player)
    {
        var players = await _playerRepository.GetAllPlayers();

        if (players.Any(registeredPlayer => registeredPlayer.Login == player.Login ||
                                            registeredPlayer.Email == player.Email))
        {
            throw new PlayerAlreadyRegisteredException(
                $"Player with login: {player.Login} email: {player.Email} already registered");
        }

        var playerPassword = BCrypt.Net.BCrypt.HashPassword(player.Password);

        var newPlayer = new PlayerSetParameters
        {
            Login = player.Login,
            Password = playerPassword,
            Email = player.Email,
            Gender = player.Gender,
            Age = player.Age
        };
        
        var playerId = await _playerRepository.SetPlayer(newPlayer);

        await _playerDataRepository.SetPlayerData(playerId);
    }
}