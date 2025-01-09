using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CryptoToolsAPI
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) 
        { 
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            //Increase maximum response size so large body responses can be sent
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 524288000;
            });

            //Improve transfer speed
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });

            services.AddAuthentication();
            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            { 
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x => 
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoToolsAPI V1");
                x.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseResponseCompression();
            app.UseMvc();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }
    }
}
