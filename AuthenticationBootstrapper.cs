using System;
using Nancy.Authentication.Stateless;

namespace Nancy.Demo.Authentication.Basic
{
    using Bootstrapper;
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
                    //for now, we will pull the apiKey from the querystring, 
                    //but you can pull it from any part of the NancyContext
                    const string key = "Bearer ";
                    string accessToken = null;

                    if (nancyContext.Request.Headers.Authorization.StartsWith(key))
                    {
                        accessToken = nancyContext.Request.Headers.Authorization.Substring(key.Length);
                    }

                    if (string.IsNullOrWhiteSpace(accessToken))
                        return null;


                    //get the user identity however you choose to (for now, using a static class/method)
                    return UserValidator.GetUserFromApiKey(accessToken);
                });

            StatelessAuthentication.Enable(pipelines, configuration);

            //pipelines.BeforeRequest += ctx =>
            //{
            //    return (!ctx.Request.Url.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)) ?
            //        (Response)HttpStatusCode.Unauthorized :
            //        null;
            //};
        }
    }
}