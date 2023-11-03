

using System.ComponentModel.DataAnnotations;
using MyMoney.Entities;

namespace MyMoney.Dtos;

public class UserAccess
{
	[Required]
	public UserRole Role { get; set; }

	[Required]
	public int UserId { get; set; }

	[Required]
	public int AccountId { get; set; }
}