using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class LoginUserDto
{
	[Required]
	[StringLength(150)]
	[EmailAddress]
	public string Email { get; set; } = null!;

	[Required]
	[StringLength(500)]
	[NoWhitespaceOnly]
	public string Password { get; set; } = null!;
}