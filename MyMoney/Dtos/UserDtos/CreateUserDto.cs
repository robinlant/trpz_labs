using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos.UserDtos;

public class CreateUserDto
{
	[Required]
	[StringLength(150)]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required]
	[StringLength(500)]
	[NoWhitespaceOnly]
	public string Password { get; set; } = null!;

	[Required]
	[StringLength(50)]
	[NoWhitespaceOnly]
	public string Username { get; set; } = null!;

	[Required]
	[StringLength(3, MinimumLength = 3)]
	[NoWhitespaceOnly]
	public string DefaultCurrency { get; set; } = null!;
}