using BlazorDemo.Data.Models;
using BlazorDemo.Server.Services;
using BlazorDemo.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContextFactory<DemoContext>();

builder.Services.AddScoped<ITodoService, TodoService>();

var app = builder.Build();

var ctxFactory = app.Services.GetRequiredService<IDbContextFactory<DemoContext>>();

using (var db = await ctxFactory.CreateDbContextAsync()) {
    await db.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
}
else {
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
