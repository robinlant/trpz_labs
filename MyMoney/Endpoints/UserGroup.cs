namespace MyMoney.Endpoints;

public static class UserGroup
{
	public static RouteGroupBuilder MapUserGroup(this RouteGroupBuilder routes)
	{
		const string route = "/users";

		var UserGroup = routes.MapGroup(route);

		return routes;
	}
}