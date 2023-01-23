using System.Reflection;
using CurrencyConverter.Application.Commands.Customer;
using CurrencyConverter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using CurrencyConverter.Application.Queries.Currency;
using CurrencyConverter.Application.Queries.CurrencyRate;
using CurrencyConverter.Application.Queries.Customer;
using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Domain.CustomerAggregate;
using CurrencyConverter.Domain.Shared;
using CurrencyConverter.Infrastructure.Configs;
using CurrencyConverter.Infrastructure.Repositories;
using MediatR;
using Autofac;
using CurrencyConverter.Infrastructure.Commands;
using Autofac.Core;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CurrencyConverterDbContext>(s => s.UseSqlite("filename=test.sqlite"));

builder.Services.AddMediatR(typeof(CreateCustomerCommand).Assembly);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.Configure<CustomerMaxLimitConfig>(builder.Configuration.GetSection("CustomerMaxLimitConfig"));

builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyRateRepository, CurrencyRateRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<ICurrencyQueries, CurrencyQueries>();
builder.Services.AddScoped<ICurrencyRateQueries, CurrencyRateQueries>();
builder.Services.AddScoped<ICustomerQueries, CustomerQueries>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    scope.ServiceProvider.GetRequiredService<CurrencyConverterDbContext>().Database.Migrate();
}
app.Run();
