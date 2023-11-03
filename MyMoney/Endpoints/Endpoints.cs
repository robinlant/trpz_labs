namespace MyMoney.Endpoints;

public static class Endpoints
{
	public static RouteGroupBuilder MapGetEndpoints(this IEndpointRouteBuilder routes)
	{
		const string mainGroupUri = "/api";

		var gamesGroup = routes.MapGroup(mainGroupUri)
			.WithParameterValidation();

		gamesGroup.MapUserGroup();
		//... and other

		return gamesGroup;
	}
}