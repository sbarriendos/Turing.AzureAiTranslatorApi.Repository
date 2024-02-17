using Application.Abstractions;
using Azure.AI.Translation.Text;
using Azure;
using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Infraestructure.Services;
using Application.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infraestructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfraestrucutre(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<TranslatorDbContext>(options => options.UseInMemoryDatabase("TranslatorDB"));

        services.AddScoped<ITranslatorRepository, TranslatorRepository>();

        services.AddScoped((context) =>
        {
            string key = config.GetConnectionString("AzureTranslatorResourceKey") ?? throw new NullReferenceException("ConnectionString AzureTranslatorResourceKey not found");
            AzureKeyCredential credential = new(key);

            string region = config.GetValue<string>("AzureTranslatorResourceRegion") ?? throw new NullReferenceException("Setting AzureTranslatorResourceRegion not found");
            return new TextTranslationClient(credential, region);
        });

        services.AddScoped<ICloudTranslatorService, AzureAiTranslatorService>();

        return services;
    }
}
