using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MyMoney.Helpers.CustomAttributes;

public class Email : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		var ERR_MSG = "Email address is required.";

		if (value is string stringValue && !IsEmail(stringValue))
		{
			return new ValidationResult(ERR_MSG);
		}

		return ValidationResult.Success;
	}

	private bool IsEmail(string stringValue)
	{
		var PATTERN = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

		return Regex.IsMatch(stringValue, PATTERN);
	}
}