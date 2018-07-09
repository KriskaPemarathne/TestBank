using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using KrisTestBank.Core.Repositories.Interfaces;
using KrisTestBank.Core.Repositories;
using KrisTestBank.Core.Services.Interfaces;
using KrisTestBank.Core.Services;
using KrisTestBank.Core.Entities;

namespace KrisTestBank.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Repository
            services.AddSingleton<IConnectionRepository, ConnectionRepository>();
            //services.AddSingleton<IRepository<Account>, AccountsRepository>();
            services.AddSingleton<IAccountsRepository, AccountsRepository>();
            services.AddSingleton<ITransactionsRepository, TransactionsRepository>();
            services.AddSingleton<ITransactionTypesRepository, TransactionTypesRepository>();
            services.AddSingleton<IUsersRepository, UsersRepository>();

            //  Services
            services.AddSingleton<IAccountsService, AccountsService>();
            services.AddSingleton<ITransactionsService, TransactionsService>();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddSingleton<ITransactionTypesService, TransactionTypesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
