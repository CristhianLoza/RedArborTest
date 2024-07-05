using Microsoft.EntityFrameworkCore;
using ms_source_get.Api;
using ms_source_get.Domain.Contracts;
using ms_source_get.Domain.Services;
using ms_source_get.Infraestructure.Services;
//using ms_source_get.Domain.Contracts;
//using ms_source_get.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IInsertRepository, InsertRepository>();
builder.Services.AddTransient<IGetRepositoy, GetRepository>();
builder.Services.AddTransient<IDeleteRepository, DeleteRepository>();
builder.Services.AddTransient<IUpdateRepository, UpdateRepository>();
builder.Services.AddSingleton<IHostedService, BackgroundServicesGet>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
