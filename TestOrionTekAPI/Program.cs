using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestOrionTekAPI.Auth.AuthenticationSettings;
using TestOrionTekAPI.Data;
using TestOrionTekAPI.Data.Entities;
using TestOrionTekAPI.Profiles;
using TestOrionTekAPI.Repo.Core;
using TestOrionTekAPI.Repo.Core.Abstract;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrionTekDbContext>(con=>con.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x=>x.MigrationsAssembly("TestOrionTekAPI.Data")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.Configure<APIKeySettings>(Configuration.GetSection("APIKeySettings"));


var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAPIKeyAuthenticationMiddleware();

app.MapControllers();

app.Run();
