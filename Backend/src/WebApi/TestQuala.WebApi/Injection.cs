using TestQuala.Business;
using TestQuala.Data;
using TestQuala.Utilitys;

namespace TestQuala.WebApi
{
    public static class Services
    {//by int. Faber Orozco
        public static void AddServiceDependency(this IServiceCollection services, UConf cnf)
        {
            //Auth Dependencys
            services.AddTransient<IBSucursal, BSucursal>();
            services.AddTransient<IDSucursal, DSucursal>();


        }
    }

}
