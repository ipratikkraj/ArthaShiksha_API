using ArthaShikshaBusiness.Implemantation;
using ArthaShikshaBusiness.Implementation;
using ArthaShikshaBusiness.Interface;
using ArthaShikshaData.ASEntity;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ArthaShiksha API", Version = "v1" });
});

// Add Rate Limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 10;
        opt.Window = TimeSpan.FromMinutes(1);
    });
});

// Database Configuration
builder.Services.AddDbContext<ASDBContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MTdbConnectionString"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)
    );
});

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy", policy =>
    {
        policy.WithOrigins(builder.Configuration.GetSection("AllowedOrigins").Get<string[]>() ?? Array.Empty<string>())
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Register Services - Final version after renaming
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserManagementSevice, UserManagementService>();
// Add Logging
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
    logging.AddDebug();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRateLimiter();
app.UseCors("DevelopmentPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
