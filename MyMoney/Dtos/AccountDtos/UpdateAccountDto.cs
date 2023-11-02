using System.ComponentModel.DataAnnotations;
using MyMoney.Helpers.CustomAttributes;

namespace MyMoney.Dtos.AccountDtos;

public class UpdateAccountDto
{
	[StringLength(50)]
	[MinLength(1)]
	[NoWhitespaceOnly]
	public string? Name { get; set; }

	[StringLength(500)]
	[NoWhitespaceOnly]
	public string? Description { get; set; }
}