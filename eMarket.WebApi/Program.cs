using System.Reflection;
using eMarket.Application;
using eMarket.Persistence;
using eMarket.Infrastructure;
using eMarket.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseCors(builder.Configuration["Cors:Blazor:Name"]!);

app.Run();
