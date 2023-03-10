using E_Commerce.Application.Validators.Products;
using E_Commerce.Infrastructure;
using E_Commerce.Infrastructure.Filters;
using E_Commerce.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceService();
builder.Services.AddInfrastructureService();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    //Adding Fluent Validation to Controller
    .AddFluentValidation(configurations =>
        configurations.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    //Avoid Validation Default Filter For Handling by Developer
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //sa
}

app.UseStaticFiles();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

