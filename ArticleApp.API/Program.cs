using System.Reflection;
using ArticleApp.API.Middlewares;
using ArticleApp.API.Modules;
using ArticleApp.Repository.Contexts;
using ArticleApp.Service.Mapping;
using ArticleApp.Service.Validations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("MsSqlConnectionString");
sqlConBuilder.UserID = builder.Configuration["uid"];
sqlConBuilder.Password = builder.Configuration["Password"];

builder.Services.AddDbContext<ArticleAppDbContext>(x =>
{
    x.UseSqlServer(sqlConBuilder.ConnectionString, option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ArticleAppDbContext)).GetName().Name);
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryServiceModule()));

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CategoryValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomException();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
