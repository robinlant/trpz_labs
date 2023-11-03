using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class UpdateUserDto
{
	[StringLength(150)]
	[EmailAddress]
	public string? Email { get; set; }

	[StringLength(500)]
	[NoWhitespaceOnly]
	public string? Password { get; set; } = null!;

	[StringLength(50)]
	[NoWhitespaceOnly]
	public string? Username { get; set; } = null!;

	[StringLength(3, MinimumLength = 3)]
	[NoWhitespaceOnly]
	public string? DefaultCurrency { get; set; } = null!;
}