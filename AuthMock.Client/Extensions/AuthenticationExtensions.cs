namespace AuthMock.Client.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorizationCore();

            serviceCollection.AddMsalAuthentication(options =>
            {
                var configuration = serviceCollection.BuildServiceProvider().GetRequiredService<IConfiguration>();
                options.ProviderOptions.LoginMode = "redirect";
                configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.ProviderOptions.DefaultAccessTokenScopes.Add("api://9fa5be43-5a21-4904-b5f0-240e31a104b3/API.Access");
            });

            return serviceCollection;
        }
    }
}
