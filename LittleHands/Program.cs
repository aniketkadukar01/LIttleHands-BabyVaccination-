using FluentValidation;
using LittleHands.Configurations;
using LittleHands.Data;
using LittleHands.MIddleWareExtensions;
using LittleHands.Repositories;
using LittleHands.Validators;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(UserDtoValidator));

builder.Services.AddScoped(typeof(ILittleHandsRepo<>), typeof(LittleHandsRepoImpl<>));


builder.Services.AddDbContext<LittleHandsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LittleHandsDBConnectionString"));
});

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

app.UseMiddleware<ExceptionHandlingMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
