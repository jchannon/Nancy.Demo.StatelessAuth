namespace APINancy
{
    using System;
    using Nancy;
    using Nancy.Authentication.Stateless;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;

    public class AuthenticationBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            // At request startup we modify the request pipelines to
            // include stateless authentication
            //
            // Configuring stateless authentication is simple. Just use the 
            // NancyContext to get the apiKey. Then, use the apiKey to get 
            // your user's identity.
            var configuration =
                new StatelessAuthenticationConfiguration(nancyContext =>
                {
                    const string key = "Bearer ";
                    string accessToken = null;

                    if (nancyContext.Request.Headers.Authorization.StartsWith(key))
                    {
                        accessToken = nancyContext.Request.Headers.Authorization.Substring(key.Length);
                    }

                    if (string.IsNullOrWhiteSpace(accessToken))
                        return null;

                    var userValidator = container.Resolve<IUserApiMapper>();

                    return userValidator.GetUserFromAccessToken(accessToken);
                });

            StatelessAuthentication.Enable(pipelines, configuration);

            //Make every request SSL based
            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
        }
    }
}