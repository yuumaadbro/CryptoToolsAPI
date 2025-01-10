using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using CryptoToolsAPI.DbContext;
using CryptoToolsAPI.DbContext.Settings;
using Microsoft.Extensions.Configuration;
using CryptoToolsAPI.Services;
using CryptoToolsAPI.DataMappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using CryptoToolsAPI.Middlewares;

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
            services.Configure<DbSettings>(_configuration.GetSection("ConnectionStrings"));
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

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();

            services.AddAuthentication(x => 
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => 
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();

            services.AddScoped<IBackOfficeService, BackOfficeService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddScoped<BackOfficeDataMapper>();
            services.AddScoped<AuthorizationDataMapper>();

            services.AddDbContext<Context>();

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

            app.UseMiddleware<CustomClaimsMiddleware>();

            app.UseMvc();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        }
    }
}
