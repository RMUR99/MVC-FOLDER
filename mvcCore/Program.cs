using Microsoft.EntityFrameworkCore;
using mvcCore.Models.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Services decleration will be here 
//...................................................................

builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("INMEMORY"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Section for Middlewares configuration  , processes before RUN ! 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// index method of home controller will be the first thing in the application 
// it is the default URL 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Person}/{action=AddPerson}/{id?}");

app.Run();
