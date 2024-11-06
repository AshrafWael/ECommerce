
using ECommerce;
using ECommerce.BLL.Authentication;
using ECommerce.BLL.AutoMapper;
using ECommerce.BLL.Middlewares;
using ECommerce.BLL.Services.Product;
using ECommerce.DAL.Data.DBHelper;
using ECommerce.DAL.Reposatories.Base;
using ECommerce.DAL.Reposatories.ProductRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ECommerce.BLL.ConfigrationsOptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using ECommerce.DAL.Data.Models;
using ECommerce.BLL.Services.Application;
namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Mapping Configration Options 
            builder.Services.Configure<AttachmentOptions>
                (builder.Configuration.GetSection("Attachment"));

            #region Add services to the container.
            builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            builder.Configuration.AddJsonFile("UserSecrets.json");
            var JwtOptions = builder.Configuration.GetSection("AuthSettings")
                .Get<JwtOptions>();
            builder.Services.AddSingleton(JwtOptions);

            #region MappingProfiles
            builder.Services.AddAutoMapper(map => map.AddProfile(new ProductMapper()));
            #endregion
            #region Services Regestration
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IAccountServices, AccountServices>();

            #endregion
            #region Reposatories 
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            #endregion

            //builder.Services.AddControllers(Option=>
            //{
            //    Option.Filters.Add<LogActivityFilter>();
            //});
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ECommerceContext>(options =>
            {
                options.UseSqlServer(builder.Configuration
                    .GetConnectionString("cs"));
            });

            #endregion
            #region Identity Configartions
            builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity
            .IdentityRole>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = false;
                Options.Password.RequireLowercase = false;
                Options.Password.RequireUppercase = true;
                Options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<ECommerceContext>();
            #endregion
            #region configaration Option and Authentcation Handeler
            /*
            builder.Services.AddAuthentication()
             .AddScheme<AuthenticationSchemeOptions,
             BasicAuthenticationHandeler>("Basic",null);
            */
            #endregion
            #region JwtBerer Token Confgartions
            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(Options =>
            {
                Options.SaveToken = true;
                Options.RequireHttpsMetadata = true;
                Options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens
                .TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtOptions.issuer,
                    ValidateAudience = true,
                    ValidAudience = JwtOptions.Audince,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(builder.Configuration["AuthSettings:Key"]))
                };
            });
            #endregion
            var app = builder.Build();
            #region Middelwares
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseMiddleware<ProfilingMiddleware>();
            app.UseMiddleware<RateLimitingMiddleware>();
            app.MapControllers();
            #endregion
            app.Run();
        }
    }
}
