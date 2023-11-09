using Dapper.FluentMap.Mapping;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Data.Mappers;

public class RegisteredPlayerMapper : EntityMap<RegisteredPlayer>
{
    public RegisteredPlayerMapper()
    {
        Map(player => player.IsPlaying).ToColumn("is_playing");
    }
}