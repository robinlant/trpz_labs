using System.ComponentModel.DataAnnotations;

namespace MyMoney.Dtos.UserDtos;

public class UserDto
{
	[Required]
	public int Id { get; set; }

	[Required]
	public string Email { get; set; } = null!;

	[Required]
	public string Username { get; set; } = null!;

	[Required]
	public DateTime JoinDate { get; set; }

	[Required]
	public string DefaultCurrency { get; set; } = null!;
}