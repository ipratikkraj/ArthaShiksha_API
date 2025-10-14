using ArthaShikshaBusiness.Implemantation;
using ArthaShikshaBusiness.Interface;
using ArthaShikshaData.ASEntity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ASDBContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("MTdbConnectionString")));
// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevelopmentPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddScoped<IAcountService, AcountService>();
builder.Services.AddScoped<IUserManagementSevice, UserManagementService>();

// Build the app BEFORE using it
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS middleware (must be after app.Build())
app.UseCors("DevelopmentPolicy");

app.UseAuthorization();
app.MapControllers();

app.Run();
