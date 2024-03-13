using MonolithicArchitecture.API.Constants;
using MonolithicArchitecture.API.Options;

namespace MonolithicArchitecture.API.DependencyInjection;
internal static class OptionsDependencyInjection
{
    internal static void AddOptionsDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailCredentialsOptions>(options => configuration.GetSection(OptionsConstants.EmailCredentialsSection).Bind(options));
    }
}
