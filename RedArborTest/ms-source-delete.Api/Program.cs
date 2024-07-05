using Microsoft.EntityFrameworkCore;
using ms_source_delete.Domain.Contracts;
using ms_source_delete.Domain.Services;
using ms_source_delete.Infraestructure.Entities.Employee;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ambiente = builder.Configuration.GetValue<string>("ambiente");
string connectionString = builder.Configuration.GetConnectionString(ambiente);

builder.Services.AddDbContext<redarbordbContext>(options =>
{
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Transient);

builder.Services.AddControllers();
builder.Services.AddTransient<IDeleteRepository, DeleteRepository>();
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
