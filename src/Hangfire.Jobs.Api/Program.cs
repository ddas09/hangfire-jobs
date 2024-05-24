using Hangfire.Jobs.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Hangfire.Jobs.Core.Extensions;
using Hangfire.Jobs.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// For generating lowecase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Adding DB context
builder.Services.RegisterDBContext(builder.Configuration.GetConnectionString("HangfireApiConnection"));

// Add Services
builder.Services.RegisterServices();
builder.Services.RegisterCoreServices();

// Add Hangfire
builder.Services.RegisterHangfire(builder.Configuration.GetConnectionString("HangfireJobsConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add hangfire dashboard
app.UseCustomHangfireDashboard();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();