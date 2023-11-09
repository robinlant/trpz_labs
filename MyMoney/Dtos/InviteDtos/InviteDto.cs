using System.ComponentModel.DataAnnotations;

namespace MyMoney.Dtos;

public record InviteDto
{
	[Required]
	public int Id { get; set; }

	[Required]
	public int AccountId { get; set; }

	[Required]
	public int SenderId { get; set; }

	[Required]
	public int InvitedUserId { get; set; }
}