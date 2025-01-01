using Microsoft.EntityFrameworkCore;
using WebBanVali.Models;
using WebBanVali.Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("QlbanVaLiContext");
builder.Services.AddCors(p => p.AddPolicy("QlbanVaLiContext", build
    =>
{
    

    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}
));
builder.Services.AddDbContext<QlbanVaLiContext>(x=>x.UseSqlServer(connectionString));
builder.Services.AddScoped<ILoaiSanPhamRespsitory, loaiSanPhamRespository>();
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");

app.Run();
