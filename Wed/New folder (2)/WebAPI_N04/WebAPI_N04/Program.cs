using Microsoft.EntityFrameworkCore;
using WebAPI_N04.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<QlbanVaLiContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("QlbanVaLiContext")));

builder.Services.AddCors(p => p.AddPolicy("QlbanVaLiContext", policy => {
    //policy.WithOrigins("https://localhost:7704").AllowAnyMethod().AllowAnyHeader();
    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors("QlbanVaLiContext");

app.UseAuthorization();

app.MapControllers();

app.Run();
