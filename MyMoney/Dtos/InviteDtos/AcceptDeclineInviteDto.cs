using System.ComponentModel.DataAnnotations;

namespace MyMoney.Dtos;

public class AcceptDeclineInviteDto
{
	[Required]
	public bool IsAccepted { get; set; }
}