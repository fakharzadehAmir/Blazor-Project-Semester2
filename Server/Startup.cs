using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using P8.Server.DB;
using Swashbuckle.AspNetCore.Swagger;
using System.Linq;

namespace P8.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors( option =>
            {
                option.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            var sqlConnectionString = "Host=ec2-52-45-179-101.compute-1.amazonaws.com;Port=5432;Database=d275duo9tbsgs8;Username=noxrsxtdolctma;Password=1de174439a298eca9d96535718d05c921747f4317855086f4fa75ae7579d4e6f;sslmode=Prefer;Trust Server Certificate=true;";
            services.AddDbContext<InstrumentDbContext>((options) => options.UseNpgsql(sqlConnectionString));
            services.AddScoped<InstrumentProvider>();
            services.AddDbContext<UserDbContext>((options) => options.UseNpgsql(sqlConnectionString));
            services.AddScoped<UserProvider>();
            services.AddMvc();
            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "a1" , new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Title is",
                    Version ="a1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/a1/swagger.json", "a1 api test");
            });
        }
    }
}
