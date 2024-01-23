using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using PizzaGameService.Data.Player.Models;
using PizzaGameService.Data.PlayerData.Models;

namespace PizzaGameService.Service.PlayerService.Requests;

public record PlayerRegistrationRequest
{
    [JsonPropertyName("login")] 
    [MinLength(3, ErrorMessage = "Логин должен быть длиной более чем 3 символа")]
    [MaxLength(20, ErrorMessage = "Логин должен быть длиной менее чем 20 символов")]
    [Required(ErrorMessage = "Логин - это обязательное поле")]
    public string Login { get; init; }

    [JsonPropertyName("password")] 
    [MinLength(7, ErrorMessage = "Пароль должен быть длиной более чем 7 символов")]
    [MaxLength(20, ErrorMessage = "Пароль должен быть длиной менее чем 20 символов")]
    [Required(ErrorMessage = "Пароль - это обязательное поле")]
    [RegularExpression(@"^(?=.*\w)(?=.*\d).+$", ErrorMessage = "Пароль должен содержать минимум одну цифру и символ")]
    public string Password { get; init; }

    [JsonPropertyName("email")] 
    [EmailAddress(ErrorMessage = "Введенное значение должно быть почтой")]
    [Required(ErrorMessage = "Почта - это обязательное поле")]
    public string Email { get; init; }

    [JsonPropertyName("age")] 
    [Range(0,120, ErrorMessage = "Допустимый возраст от 0 до 120 лет")]
    [RegularExpression(@"\d+", ErrorMessage = "Возраст должен быть числом")]
    public int? Age { get; init; }

    [JsonPropertyName("gender")]
    [Range(0,1)]
    public Gender? Gender { get; init; }
}