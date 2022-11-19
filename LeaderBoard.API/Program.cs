using LeaderBoard.API.Controllers;
using LeaderBoard.Core.Repositories;
using LeaderBoard.Core.Services;
using LeaderBoard.Core.UnitOfWork;
using LeaderBoard.DataAccessLayer;
using LeaderBoard.DataAccessLayer.Repositories;
using LeaderBoard.DataAccessLayer.UnitOfWork;
using LeaderBoard.Service.Mapping;
using LeaderBoard.Service.Service;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<LeaderBoardDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"))
);
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddCors(options =>
{
    
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

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

