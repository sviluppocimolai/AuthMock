using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using System.Linq;

namespace AuthMock.Server.Extensions
{
    public static class OpenApiExtensions
    {
        public static IServiceCollection AddOpenApi(this IServiceCollection services, string apiTitle, string apiVersion, bool useJwtBearerToken, bool useXmlComments = true)
        {
            services.AddOpenApiDocument(document =>
            {
                document.Title = apiTitle;
                document.Version = apiVersion;
                document.UseControllerSummaryAsTagDescription = useXmlComments;

                if (useJwtBearerToken)
                {
                    document.AddSecurity("Bearer", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "JWT Authorization header using the Bearer scheme."
                    });

                    document.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("Bearer"));
                }
            });

            return services;
        }

        public static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, string apiTitle, string cssPath = null, string javaScriptPath = null)
        {
            app.UseOpenApi();

            app.UseSwaggerUi3(conf =>
            {
                conf.DocumentTitle = apiTitle;

                if (cssPath != null) conf.CustomStylesheetPath = cssPath;
                if (javaScriptPath != null) conf.CustomJavaScriptPath = javaScriptPath;

                conf.Path = "";
            });

            return app;
        }
    }
}
