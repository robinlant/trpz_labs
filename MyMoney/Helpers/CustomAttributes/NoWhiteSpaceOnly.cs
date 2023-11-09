using System.ComponentModel.DataAnnotations;

namespace MyMoney.Helpers.CustomAttributes;

public class NoWhitespaceOnly : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		var ERR_MSG = "The field cannot contain only whitespace.";

		if (value is string stringValue && string.IsNullOrWhiteSpace(stringValue))
		{
			return new ValidationResult(ERR_MSG);
		}
		return ValidationResult.Success;
	}
}