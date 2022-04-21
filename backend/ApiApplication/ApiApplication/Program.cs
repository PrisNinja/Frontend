using ApiApplication.Database;
using ApiApplication.Database.Data;
using ApiApplication.Database.Models;
using ApiApplication.HostedServices;
using ApiApplication.SearchAlgorithm;
using Microsoft.EntityFrameworkCore;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PrisninjaDbContext>(options =>
{
    options.UseSqlServer("" +
                         "Data Source=localhost;" +
                         "Database=TestDB;" +
                         "TrustServerCertificate=true;" +
                         "User ID=SA;" +
                         "PASSWORD=<Tofirebananer147>");
});
builder.Services.AddTransient<IDbRequest, PrisninjaDb>();
builder.Services.AddTransient<IDbSearch, PrisninjaDb>();
builder.Services.AddTransient<IDbInsert, PrisninjaDb>();
builder.Services.AddTransient<CheapestSearcher>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

builder.Services.AddHostedService<FoetexService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();