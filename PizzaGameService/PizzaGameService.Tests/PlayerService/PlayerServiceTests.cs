using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using PizzaGameService.Data.PlayerData.Interfaces;
using PizzaGameService.Service.Exceptions;
using PizzaGameService.Service.PlayerService.Implementations;
using PizzaGameService.Service.PlayerService.Interfaces;
using PizzaGameService.Service.PlayerService.Requests;
using PizzaGameService.Tests.PlayerService.Mock;

namespace PizzaGameService.Tests.PlayerService;

public class PlayerServiceTests
{
    private IPlayerAuthorizationService _authorizationService = null!;

    private static readonly PlayerAuthorizationRequest DefaultAuthorizationRequest = new()
    {
        PlayerLogin = "test",
        PlayerPassword = "test",
    };

    private static readonly PlayerRegistrationRequest DefaultRegistrationRequest = new()
    {
        PlayerLogin = "test",
        PlayerPassword = "test",
        PlayerEmail = "test",
    };

    [SetUp]
    public void SetUp()
    {
        var testRepository = new PlayerRepositoryMock();
        
        _authorizationService = new PlayerAuthorizationService(testRepository, testRepository);
    }

    [Test]
    public async Task SimpleRegistrationTest()
    {
        var id = await _authorizationService.SignUp(DefaultRegistrationRequest);

        id.Should().Be(0);
    }

    [Test]
    public async Task PlayerAlreadyRegisteredTest()
    {
        await _authorizationService.SignUp(DefaultRegistrationRequest);

        Func<Task<int>> act = async () => await _authorizationService.SignUp(DefaultRegistrationRequest);

        await act.Should().ThrowAsync<PlayerAlreadyRegisteredException>();
    }

    [Test]
    public async Task SimpleAuthorizationTest()
    {
        var expectedId = await _authorizationService.SignUp(DefaultRegistrationRequest);

        var actualId = await _authorizationService.SingIn(DefaultAuthorizationRequest);

        actualId.Should().Be(expectedId);
    }
    
    [Test]
    public async Task PlayerWithIncorrectLoginTest()
    {
        await _authorizationService.SignUp(DefaultRegistrationRequest with{PlayerLogin = "test2"});

        Func<Task<int>> act = async () => await _authorizationService.SingIn(DefaultAuthorizationRequest);

        await act.Should().ThrowAsync<PlayerNotVerifyException>();
    }
    
    [Test]
    public async Task PlayerWithIncorrectPasswordTest()
    {
        await _authorizationService.SignUp(DefaultRegistrationRequest with{PlayerPassword = "test2"});

        Func<Task<int>> act = async () => await _authorizationService.SingIn(DefaultAuthorizationRequest);

        await act.Should().ThrowAsync<PlayerNotVerifyException>();
    }
    
    [Test]
    public async Task PlayerAlreadyPlayingTest()
    {
        await _authorizationService.SignUp(DefaultRegistrationRequest);

        await _authorizationService.SingIn(DefaultAuthorizationRequest);

        Func<Task<int>> act = async () => await _authorizationService.SingIn(DefaultAuthorizationRequest);

        await act.Should().ThrowAsync<PlayerAlreadyPlayingException>();
    }
}