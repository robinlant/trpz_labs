using System.ComponentModel.DataAnnotations;
using MyMoney.Entities;

namespace MyMoney.Dtos;

public record UpdateUserAccessDto
{
	[Required]
	public UserRole Role { get; set; }

	[Required]
	public int UserId { get; set; }
}