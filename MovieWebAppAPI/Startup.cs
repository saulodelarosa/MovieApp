using Infrastructure.Repositories;
using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Movieshop.API.CustomMiddleware;

namespace Movieshop.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration config)
        {
                Configuration= config;
        }
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddControllers();
            service.AddCors(option => {
                option.AddDefaultPolicy(builder => {
                    builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });

            service.AddScoped<IGenreRepository, GenreRepository>();
            service.AddScoped<IMovieRepository, MovieRepository>();
            service.AddScoped<ICastRepository, CastRepository>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<IGenreService, GenreService>();
            service.AddScoped<IMovieService, MovieService>();
            service.AddScoped<ICastService, CastService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddDbContext<MovieWebAppDbContext>( option=> {
               option.UseSqlServer(Configuration.GetConnectionString("MovieShopDB"));
           });

            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey=true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["PrivateKey"]))
                    };
                
                }
                
                );

          
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { 
            app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionMiddleware();
            app.UseEndpoints(endpoints => {
               endpoints.MapControllers();
            });

           
        }
    }
}
