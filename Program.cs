using FluentValidation;
using FluentValidation.AspNetCore;
using LIBRARYMVC_TEST.Models;
using LIBRARYMVC_TEST.Models.ViewModels;
using LIBRARYMVC_TEST.Validator;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddTransient<IValidator<Author>, AuthorValidator>();
builder.Services.AddTransient<IValidator<BookVM>, BookValidator>();

builder.Services.AddDbContext<DbLibraryMvcContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
