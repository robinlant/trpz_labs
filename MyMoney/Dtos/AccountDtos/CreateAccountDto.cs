using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class CreateAccountDto
{
	[Required]
	[StringLength(50)]
	[NoWhitespaceOnly]
	public string Name { get; set; } = null!;

	[StringLength(3, MinimumLength = 3)]
	[NoWhitespaceOnly]
	public string? CurrencyCode { get; set; }

	[StringLength(500)]
	[NoWhitespaceOnly]
	public string? Description { get; set; }
}