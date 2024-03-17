using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevAlApplication.StartupConfig
{
    public static class SwaggerExtensions
    {
        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevAI Portal");
                    c.OAuthClientId(configuration["SwaggerUiClientId"]);
                    c.OAuthAppName("DevAI Swagger UI");
                });
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HTTP Api",
                    Version = "v1",
                    Description = " HTTP Api"
                });

                options.OperationFilter<RemoveDuplicatePropertiesOperationFilter>();
                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            return services;
        }
    }

    public class AuthorizeCheckOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Check for authorize attribute
            var hasAuthorize = context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() ||
                               context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (!hasAuthorize)
            {
                return;
            }

            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
            operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });

            var oAuthScheme = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            };

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [ oAuthScheme ] = new [] { "orchestrationengineapi" }
                }
            };
        }
    }

    public class AuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeFilter);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized && !allowAnonymous)
            {
                if (operation.Parameters == null)
                {
                    operation.Parameters = new List<OpenApiParameter>();
                }

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Description = "access token",
                    Required = true
                });
            }
        }
    }

    public class RemoveDuplicatePropertiesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
            {
                return;
            }

            if (context.ApiDescription.HttpMethod == "GET")
            {
                operation.RequestBody = null;
            }
            var complexParameters = operation.Parameters.Where(x => x.In == ParameterLocation.Query && !string.IsNullOrWhiteSpace(x.Name)).ToArray();
            var pathParameters = operation.Parameters.Where(x => x.In == ParameterLocation.Path && !string.IsNullOrWhiteSpace(x.Name)).ToArray();

            if (!pathParameters.Any())
            {
                return;
            }
            foreach (var parameter in complexParameters)
            {
                if (pathParameters.Any(x => x.Name == parameter.Name))
                {
                    operation.Parameters.Remove(parameter);
                }
            }
        }
    }
}