using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using API.Interfaces;
using API.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // required
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DatingApp API", Version = "v1" });
});

 builder.Services.AddDbContext<DataContext>(opt =>
 {
     opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
 });
builder.Services.AddCors();
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();
app.UseAuthorization();



app.MapControllers();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "DatingApp API v1");
    });
}

app.Run();
