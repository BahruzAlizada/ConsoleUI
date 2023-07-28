using Autofac.Extensions.DependencyInjection;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);
Host.CreateDefaultBuilder(args).UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Add services to the container.
//Autofac,Ninject,CastleWindsor,StructoreMap,LightInject,DryInject-->IoC Container
//AOP-Bir Metodun əvvəlində axrında çalışan kod parçalarıdır.

builder.Services.AddControllers();

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
