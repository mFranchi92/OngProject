using Amazon.S3;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OngProject.Core.Entities;
using OngProject.Core.Interfaces.IRepositories;
using OngProject.Core.Interfaces.IServices;
using OngProject.Core.Interfaces.IServices.IAuth;
using OngProject.Core.Interfaces.IServices.IGetUri;
using OngProject.Core.Interfaces.IUnitOfWork;
using OngProject.Core.Middleware;
using OngProject.Core.Services;
using OngProject.Core.Services.Auth;
using OngProject.Core.Services.GetUri;
using OngProject.Infrastructure.Data;
using OngProject.Infrastructure.Repositories;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OngProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            //aws sdk
            services.AddAWSService<IAmazonS3>();

            //Configure dbContext
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            //UnitOfWork
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IActivityService, ActivityService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IMemberService, MemberService>();
            services.AddTransient<IOrganizationService, OrganizationService>();
            services.AddTransient<ITestimonialService, TestimonialService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ISlideService, SlideService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMailService, MailService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IContactService, ContactService>();

            //Get url localhost
            services.AddSingleton<IUriService>(provider => 
            {
                var accesor = provider.GetRequiredService<IHttpContextAccessor>();
                var request = accesor.HttpContext.Request;
                var absoluteUri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(absoluteUri);
            });

            //identity authentication
            services.AddIdentity<User, Rol>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();


            //Add Authentication
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["TokenAuthentication:Issuer"],
                    ValidAudience = Configuration["TokenAuthentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(Configuration["TokenAuthentication:SecretKey"])),
                };

            });
            services.AddScoped<IAuthUserService, AuthUserService>();
            
            //
            services.AddControllers();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OngProject", Version = "v1" });
                
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                // Authorize header in Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    { new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                            },
                      new string[] {}
                    }
                });

              

            });

            services.AddAuthorization();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "OngProject v1");
                    c.RoutePrefix = "api/docs";
                    });
            }

            //app.UseMiddleware<RoutesRestriction>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
