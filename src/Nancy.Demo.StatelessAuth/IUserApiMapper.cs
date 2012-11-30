namespace Nancy.Demo.StatelessAuth
{
    using Nancy.Security;

    public interface IUserApiMapper
    {
        IUserIdentity GetUserFromAccessToken(string accessToken);
    }
}