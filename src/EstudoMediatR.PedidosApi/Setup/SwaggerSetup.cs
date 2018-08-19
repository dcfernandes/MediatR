using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace EstudoMediatR.PedidosApi.Setup
{
    public static class SwaggerSetup
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Estudo MediatR",
                    Description = "Estudo MediatR API Swagger",
                    Contact = new Contact { Name = "Diogo Carvalho Fernandes", Email = "cfernandes.diogo@gmail.com" },

                });
            });
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudo MediatR");
            });
        }
    }
}
