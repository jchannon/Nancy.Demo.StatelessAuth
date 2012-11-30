namespace APINancy
{
    using Nancy.Security;

    public interface IUserApiMapper
    {
        IUserIdentity GetUserFromAccessToken(string accessToken);
    }
}