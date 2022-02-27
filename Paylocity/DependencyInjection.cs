using Paylocity.Handlers;
using Paylocity.Handlers.Interfaces;

namespace Paylocity
{
    public static class DependencyInjection
    {
        public static void AddHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRulesHandler, RulesHandler>();
            services.AddTransient<IDataHandler, DataHandler>();
            services.AddTransient<IPersonHandler, PersonHandler>();

            
        }
    }
}
