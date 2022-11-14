using Mod.ActivityPub.Example.Services;
using Mod.ActivityPub.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();

// Add Resource Lookup service to provide resource information to the ActivityPub UI controllers
builder.Services.AddScoped<IResourceLookup, ResourceLookup>();

builder.Services.AddControllersWithViews()
    // Add ActivityPub UI controllers
    .AddActivityPubUI();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
