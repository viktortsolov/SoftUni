namespace CarRentingSystem.Infrastructure
{
    using System.Security.Claims;

    public static class CalimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
