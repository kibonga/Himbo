using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.DataAccess
{
    public static class DataAccessServicesRegistration
    {
        public static IServiceCollection ConfigureDataAccessServices(this IServiceCollection services, string connString)
        {
            #region Database
            services.AddTransient(x =>
            {
                #region Get Connection String - Legacy
                //var connString = x.GetService<AppSettings>().ConnString; // Get ConnString from AppSettings property, which is binded to connString "key" in appsettings.Development.json
                #endregion

                #region Options builder
                var optionsBuilder = new DbContextOptionsBuilder();
                // We need it to define options sets
                #endregion

                #region Set Options
                optionsBuilder.UseSqlServer(connString).UseLazyLoadingProxies(); // Use SqlServer and set Lazy loading 
                var options = optionsBuilder.Options;
                #endregion

                return new HimboDbContext(options);
            });
            #endregion

            return services;
        }
    }
}
