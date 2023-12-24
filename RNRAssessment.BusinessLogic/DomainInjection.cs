using Microsoft.Extensions.DependencyInjection;
using RNRAssessment.DAL;

namespace RNRAssessment.BusinessLogic
{
    public static class DomainInjection
    {
        public static void InjectBusinessLogic(this IServiceCollection Services)
        {
            Services.AddScoped<IBreakdownLogic, BreakdownLogic>();
        }

        public static void InjectRepositories(this IServiceCollection Services)
        {
            Services.AddScoped<IBreakdownRepository,BreakdownRepository>();
            Services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}
