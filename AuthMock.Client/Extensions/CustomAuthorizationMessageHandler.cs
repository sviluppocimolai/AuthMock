using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace AuthMock.Client.Extensions
{
    /// <summary>
    /// Far riferimento a  https://docs.microsoft.com/it-it/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-5.0#custom-authorizationmessagehandler-class
    /// </summary>

    public class CustomAuthorizationMessageHandler : AuthorizationMessageHandler
    {
        public CustomAuthorizationMessageHandler(IAccessTokenProvider provider, NavigationManager navigationManager) : base(provider, navigationManager)
        {
            ConfigureHandler(authorizedUrls: new[] { "https://localhost:44362/"});
        }
    }
}
