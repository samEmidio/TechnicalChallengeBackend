using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalChallenge.Infra.Data.Context;

namespace TechnicalChallenge.Infra.Data
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            

            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<TechnicalChallengeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }




    }
}
