namespace MovieWebAppAPI.Helpers
{
    public interface ICurrentLoginUserService
    {
        int UserId { get; }
        string FullName { get; }
        string Email { get; }
        List<string> Roles { get; set; }
        bool IsAdmin { get; }
    }
}
