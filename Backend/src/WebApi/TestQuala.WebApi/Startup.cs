using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestQuala.Data.Models;
using TestQuala.Utilitys;

namespace TestQuala.WebApi
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            var cnf = new UConf(Configuration);

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "Prueba Tecnica Quala",
                    Title = "Quala API",
                    Version = "v1",
                });
               
            });

            services.AddCors(o => o.AddPolicy("testQuala", builder => {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }));





            services.AddTransient<IUConfiguration, UConfiguration>();
            services.AddTransient<IULogger, ULogger>();



            //Add Context Main
            services.AddDbContext<ContextMain>(options => options.UseSqlServer(cnf.DbConnectionString()), ServiceLifetime.Transient);
            services.AddServiceDependency(cnf);

        }


        public void configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }
  

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("testQuala");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endspoints =>
            {
                endspoints.MapControllers();
            });
        }
    }

}
