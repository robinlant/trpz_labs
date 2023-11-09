using System.ComponentModel.DataAnnotations;

namespace MyMoney.Dtos;

public record AcceptDeclineInviteDto
{
	[Required]
	public bool IsAccepted { get; set; }
}