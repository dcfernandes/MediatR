namespace EstudoMediatR.PedidosApi.Setup
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Reflection;

    public static class MediatRSetup
    {
        public static void ConfigureMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("EstudoMediatR.Applciation");
            services.AddMediatR(assembly);

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
        }
    }
}
