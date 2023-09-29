using System.Linq;
using AccountingApp.Application.Configurations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountingApp.Server.Extensions
{
    internal static class MvcBuilderExtensions
    {
        internal static IMvcBuilder AddValidators(this IMvcBuilder builder)
        {
            builder.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AppConfiguration>());
            return builder;
        }
    }
}