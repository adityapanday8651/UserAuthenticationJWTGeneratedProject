using Microsoft.EntityFrameworkCore;
using UserAuthenticationJWTGenerated.Data;
using UserAuthenticationJWTGenerated.Helpers;
using UserAuthenticationJWTGenerated.Interfaces;
using UserAuthenticationJWTGenerated.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<UsersContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConnStr");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
.WithOrigins(new[] {"http://localhost:3000", "http://localhost:8080" , "http://localhost:4200"})
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
