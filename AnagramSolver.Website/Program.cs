using BuisnessLogic;
using Contracts;
using Anagram.Database;
using Contracts.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IAnagramGenerator, AnagramGenerator>();
builder.Services.AddTransient<ITxtReader, TxtReader>();
builder.Services.AddTransient<IDictGenerator, DictionaryGenerator>();
builder.Services.AddTransient<IWordSorter, WordSorter>();
builder.Services.AddTransient<IInputControler, InputControler>();
builder.Services.AddTransient<IWordRepository, DataBaseWordRepository>();
builder.Services.AddTransient<ICachedWord, CachedWord>();


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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default", // nesupranta, kas default'as kontroleris ar id
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "defaultDictionary", // nesupranta, kas default'as kontroleris ar id
        pattern: "{controller=Home}/{action=WordsList}");

    endpoints.MapControllerRoute(
        name: "defaultId", // nesupranta, kas default'as kontroleris ar id
        pattern: "{id?}",
        defaults: new { controller = "Home", action = "Index" }
        );
});

app.Run();
