namespace Nancy.Demo.StatelessAuth
{
    using Nancy.Security;

    public class UserApiMapper : IUserApiMapper
    {
        public IUserIdentity GetUserFromAccessToken(string accessToken)
        {
            if (accessToken == "fred")
                return new DemoUserIdentity { UserName = "Fred" };

            return null;
        }
    }
}