using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace EstudoMediatR.PedidosApi.Setup
{
    public static class MediatRSetup
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.MeasureTime<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(Pipelines.ValidateCommand<,>));

            var assembly = AppDomain.CurrentDomain.Load("EstudoMediatR.Applciation");
            services.AddMediatR(assembly);

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.Scan(scan => scan.FromAssembliesOf(typeof(IRequestHandler<,>)).AddClasses().AsImplementedInterfaces());
            services.Scan(scan => scan.FromAssembliesOf(typeof(RequestHandler<>)).AddClasses().AsImplementedInterfaces());
        }
    }
}
