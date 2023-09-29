using Application.Core.Validation.Funcionarios;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace Application.Infra.Crosscuting
{
    public static class FluentvalidationConfig
    {
        [System.Obsolete]
        public static void AddFluentValidationConfig(this IServiceCollection services)
        {
            services.AddMvc()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CommandFuncionariosValidation>();
                    fv.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
                });
        }
    }
}
