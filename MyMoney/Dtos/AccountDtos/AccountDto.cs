using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos.AccountDtos;

public class AccountDto
{
	public int Id { get; set; }

	[Required]
	[StringLength(50)]
	[NoWhitespaceOnly]
	public string Name { get; set; }

	[Required]
	[StringLength(3, MinimumLength = 3)]
	[NoWhitespaceOnly]
	public string CurrencyCode { get; set; }

	[Required]
	[StringLength(10)]
	[NoWhitespaceOnly]
	public string Role { get; set; }

	[Required]
	public DateTime CreationDate { get; set; }

	[StringLength(500)]
	[NoWhitespaceOnly]
	public string? Description { get; set; }
}