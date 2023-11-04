namespace MyMoney.Endpoints;

public static class Endpoints
{
	public static RouteGroupBuilder MapGetEndpoints(this IEndpointRouteBuilder routes)
	{
		const string mainGroupUri = "/api";

		var mainGroup = routes.MapGroup(mainGroupUri)
			.WithParameterValidation();

		mainGroup.MapUserGroup();
		//... and other

		return mainGroup;
	}
}