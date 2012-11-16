namespace Nancy.Demo.Authentication.Basic
{
    using Nancy.Security;

    public class UserValidator
    {
        public static IUserIdentity GetUserFromApiKey(string apiKey)
        {
            if (apiKey == "fred")
                return new DemoUserIdentity { UserName = "Fred" };

            return null;
        }
    }
}