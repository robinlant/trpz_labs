using System.ComponentModel.DataAnnotations;

namespace MyMoney.Dtos;

public record CreateInviteDto
{
	[Required]
	public int AccountId { get; set; }

	[Required]
	public int InvitedUserId { get; set; }
}