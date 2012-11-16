using Nancy.Security;

namespace Nancy.Demo.Authentication.Basic
{
    public class MainModule : NancyModule
    {
        public MainModule()
        {
            this.RequiresAuthentication();

            Get["/GetData"] = parameters =>
                                  {
                                      var data = new { Name = "John", LastName = "Smith" };

                                      return Negotiate.WithModel(data);
                                  };
        }
    }
}