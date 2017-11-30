using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SoundsUp.Data.Models;
using SoundsUp.WebHost.IoC;
using StructureMap;
using System;
using System.Text;

namespace SoundsUp.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the Secret phrase"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                // TODO Security here
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    // TODO Token expiration here :)
                    IssuerSigningKey = signingKey,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                };
            });

            services.AddMvc();

            var connection = @"Server=tcp:projectnorth.database.windows.net,1433;Initial Catalog=SoundsUpSQLDatabase;Persist Security Info=False;User ID=RootAdmin;Password=DatabaseIsAwesome1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            services.AddDbContext<SoundsUpSQLDatabaseContext>(options => options.UseSqlServer(connection));

            return ConfigureIoC(services);
        }

        /**
         * Configure using Inversion of Control pattern.
         * This method configures the automatic mapping for dependency injection. 
         * Map between the injected classes and their interfaces.
         */
        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container(new RuntimeRegistry());
            container.Configure(config => config.Populate(services));

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}