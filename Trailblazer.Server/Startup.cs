using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Trailblazer.Server.Data.Contexts;
using Trailblazer.Server.Data.Repositories;
using Trailblazer.Server.Models;

namespace Trailblazer.Server
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
            services.AddControllers();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Trailblazer API",
                    Version = "v1",
                    Description = "ASP.NET Core Web API for Trailblazer Application",
                    TermsOfService = new Uri("https://websitewithtos.com"),
                    Contact = new OpenApiContact
                    {
                        Name = "Coop",
                        Email = string.Empty,
                        Url = new Uri("https://websitegoeshere.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Raccoon License (my trash)",
                        Url = new Uri("https://licensegoeshere.com")
                    }
                });
            });
            services.Configure<AppSettings>(Configuration);

            services.AddDbContextPool<TrailblazerDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), sqlServerOptions => sqlServerOptions.CommandTimeout(300)));

            services.AddTransient<AppDb>(_ => new AppDb(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IDataTrailblazer, DataTrailblazer>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
