using PropertyManagementSystem.Data;
using PropertyManagementSystem.Repositories;
using PropertyManagementSystem.Repositories.Contracts;
using PropertyManagementSystem.Services;
using PropertyManagementSystem.Services.Contracts;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

namespace PropertyManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<DapperContext>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
            builder.Services.AddScoped<IRequestRepository, RequestRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IRequestService, RequestService>();
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ILandlordService, LandlordService>();
            builder.Services.AddScoped<ITenantService, TenantService>();

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Property Management System API",
                    Description = "PMS API Swagger documentation",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Property Management System API v1");
                    //c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.MapDefaultControllerRoute();

            app.MapControllers();

            app.Run();
        }
    }
}