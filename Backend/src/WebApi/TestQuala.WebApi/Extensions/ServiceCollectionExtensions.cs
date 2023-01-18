using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestQuala.Business;
using TestQuala.Data;
using TestQuala.Data.Models;
using TestQuala.Utilitys;

namespace TestQuala.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "Prueba Tecnica Quala",
                    Title = "Quala API",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Ing. Faber Orozco",
                        Url = new Uri("https://www.quala.com.co/")
                    }
                });
            });

            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "http://localhost:4200/", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            return services;
        }


        public static IServiceCollection AddConfigureServices(this IServiceCollection services, IConfiguration config)
        {
            var cnf = new UConf(config);

            services.AddControllers();
            services.AddHttpContextAccessor();

            //Utilitys
            services.AddTransient<IUConfiguration, UConfiguration>();
            services.AddTransient<IULogger, ULogger>();

            //Auth Dependencys
            services.AddTransient<IBSucursal, BSucursal>();
            services.AddTransient<IDSucursal, DSucursal>();

            //Add Context Main
            services.AddDbContext<ContextMain>(options => options.UseSqlServer(cnf.DbConnectionString()), ServiceLifetime.Transient);


            return services;
        }
    }

}
