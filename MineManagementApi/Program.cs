using Microsoft.EntityFrameworkCore;
using MineManagementApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MineManagementApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MineManagementApiDbConnectionString"));
});

//Migrate The database to the newest version
using (MineManagementApiDbContext dbContext = new MineManagementApiDbContext(
    new DbContextOptionsBuilder().UseSqlServer(builder.Configuration.GetConnectionString("MineManagementApiDbConnectionString")).Options))
{
    dbContext.Database.Migrate();
}

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
