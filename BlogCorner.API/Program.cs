using BlogCorner.API.Data;
using BlogCorner.API.Repository;
using BlogCorner.API.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICategoryRepository, CategoryService>();
builder.Services.AddScoped<IBlogPostRepository, BlogPostService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(Options =>
{
    Options.AllowAnyHeader();
    Options.AllowAnyOrigin();
    Options.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
