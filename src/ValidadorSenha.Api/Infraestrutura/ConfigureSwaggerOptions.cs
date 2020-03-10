using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

/*
    Retrieved from: https://github.com/microsoft/aspnet-api-versioning/tree/master/samples/aspnetcore/SwaggerSample
    following tutorial from: https://tim.covatrix.com/posts/api-ver/
*/
namespace ValidadorSenha.Api.Infraestrutura
{
    /// <summary>
    /// Configures the Swagger generation options.
    /// </summary>
    /// <remarks>This allows API versioning to define a Swagger document per API version after the
    /// <see cref="IApiVersionDescriptionProvider"/> service has been resolved from the service container.</remarks>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options) => 
            CriarDocumentosParaCadaVersãoDaAPI(options);

        private void CriarDocumentosParaCadaVersãoDaAPI(SwaggerGenOptions options) 
        {
            foreach (var descrição in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(descrição.GroupName, CriarInformaçõesParaAVersãoDaAPI(descrição));
            }
        }

        static OpenApiInfo CriarInformaçõesParaAVersãoDaAPI(ApiVersionDescription descrição)
        {
            var info = new OpenApiInfo()
            {
                Title = "API validadora de senha",
                Version = descrição.ApiVersion.ToString(),
                Description = "Uma API validadora de senha criada com Swagger, Swashbuckle e versionamento.",
                Contact = new OpenApiContact() { Name = "William Porto", Email = "williamporto19@gmail.com" }
            };

            if (descrição.IsDeprecated)
            {
                info.Description += " Esta API está obsoleta.";
            }

            return info;
        }
    }
}
