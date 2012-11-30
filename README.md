#Nancy.Demo.StatelessAuth

This is a demo for showing how you can implement stateless authentication in you Nancy applications.

When a request is made to the application it checks for a token in a authorization header.

This is then passed to a user validator class which returns a IUserIdentity if the user is deemed valid.

If the user is not validated then the request is not allowed to continue