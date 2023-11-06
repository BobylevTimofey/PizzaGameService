using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Data.PlayerData.Models;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.PlayerService.Requests;

namespace PizzaGameService.Service.PlayerService.Implementations;

public class PlayerAuthorizationService : IPlayerAuthorizationService
{
    private readonly IPlayerRepository _playerRepository;
    private readonly IPlayerActiveRepository _playerActiveRepository;

    public PlayerAuthorizationService(IPlayerRepository playerRepository,
        IPlayerActiveRepository playerActiveRepository)
    {
        _playerRepository = playerRepository;
        _playerActiveRepository = playerActiveRepository;
    }

    public async Task<int> SingIn(PlayerAuthorizationRequest player)
    {
        var players = await _playerRepository.GetAllPlayers();

        var registeredPlayer = players.FirstOrDefault(registeredPlayer =>
            registeredPlayer.Login == player.PlayerLogin &&
            BCrypt.Net.BCrypt.Verify(player.PlayerPassword, registeredPlayer.Password));

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

    public async Task<int> SignUp(PlayerRegistrationRequest player)
    {
        var players = await _playerRepository.GetAllPlayers();

        if (players.Any(registeredPlayer => registeredPlayer.Login == player.PlayerLogin &&
                                            registeredPlayer.Email == player.PlayerEmail))
        {
            throw new PlayerAlreadyRegisteredException(
                $"Player with login: {player.PlayerLogin} email: {player.PlayerEmail} already registered");
        }

        var playerPassword = BCrypt.Net.BCrypt.HashPassword(player.PlayerPassword);

        var newPlayer = new PlayerSetParameters
        {
            Login = player.PlayerLogin,
            Password = playerPassword,
            Email = player.PlayerEmail,
            Gender = player.PlayerGender,
            Age = player.PlayerAge
        };
        var idPlayer = await _playerRepository.SetPlayer(newPlayer);

        return idPlayer;
    }
}