using Microsoft.EntityFrameworkCore;
using PokemonAPI.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PokemonDbContext>(options => options.UseSqlite("Data Source=PokemonDB.db"));

//Setting Cors Policy
builder.Services.AddCors(c =>
{
    c.AddPolicy("CorsPolicy", build =>
    build.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader());
});



builder.Services.AddDbContext<PokemonDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
