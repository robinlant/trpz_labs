using System.ComponentModel.DataAnnotations;

namespace MyMoney.Helpers.CustomAttributes;

public class NoWhitespaceOnly : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is string stringValue && string.IsNullOrWhiteSpace(stringValue))
		{
			return new ValidationResult("The field cannot contain only whitespace.");
		}
		return ValidationResult.Success;
	}
}