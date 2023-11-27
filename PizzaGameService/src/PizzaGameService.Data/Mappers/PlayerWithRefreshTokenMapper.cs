using Dapper.FluentMap.Mapping;
using PizzaGameService.Data.PlayerToken.Models;

namespace PizzaGameService.Data.Mappers;

public class PlayerWithRefreshTokenMapper : EntityMap<PlayerWithRefreshToken>
{
    public PlayerWithRefreshTokenMapper()
    {
        Map(player => player.RefreshToken).ToColumn("refresh_token");
        Map(player => player.TimeTokenCreated).ToColumn("time_token_created");
        Map(player => player.TimeTokenExpires).ToColumn("time_token_expires");
    }
}