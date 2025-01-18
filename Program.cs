using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace LMS_Machinetest6_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            //Register JWT authentication schema
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  //Adds JWT authentication to secure the application.
            .AddJwtBearer(opt =>               //Configures the JWT validation options, such as:Validating the token issuer, audience, lifetime, and signature key.
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],  //Reads the Issuer (who issued the token) from the configuration file.
                    ValidAudience = builder.Configuration["Jwt : Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                        builder.Configuration["Jwt:Key"]))        //Reads the secret key for token validation from the configuration.

                };
            });

            builder.Services.AddControllersWithViews().AddJsonOptions(
               options =>
               {
                   options.JsonSerializerOptions.PropertyNamingPolicy = null;
                   //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                   options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                   options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                   options.JsonSerializerOptions.WriteIndented = true;
               });

            builder.Services.AddDbContext<DemoAugust2024DbContext>(
              options => options.UseSqlServer(builder.Configuration.GetConnectionString("PropelAug24Connection")));

            //2-Register repository and service layer
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>(); 

            //SWAGGER 
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //Enable CORS
            app.UseCors("AllowAllOrigin");

            // Configure the HTTP request pipeline.

            //swagger middleware
            if (app.Environment.IsDevelopment())  //Checks if the app is running in the Development environment.
            {
                app.UseSwagger();  //Enables Swagger for API documentation.
                app.UseSwaggerUI();  //Sets up the user interface for Swagger.
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
