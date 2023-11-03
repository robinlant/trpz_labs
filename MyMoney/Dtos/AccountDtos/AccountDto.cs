using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos;

public class AccountDto
{
	[Required]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = null!;

	[Required]
	public string CurrencyCode { get; set; } = null!;

	[Required]
	public int OwnerId { get; set; }

	[Required]
	public DateTime CreationDate { get; set; }

	public string? Description { get; set; }
}