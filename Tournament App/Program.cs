using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Data;
using Tournament_App.Middleware;
using Tournament_App.Models;
using Tournament_App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration["ConnectionStrings:SQLConnection"];

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddScoped<IFeatureControl, FeatureControlLogic>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    string seedUserPassword = builder.Configuration["SeedUserPW"];

    await SeedData.Initialize(services, seedUserPassword);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/puzzles"), subApp =>
{
    subApp.Use(async (context, next) =>
    {
        IFeatureControl? fc = context.RequestServices.GetService<IFeatureControl>();
        if (fc == null || fc.IsEnabled(Constants.ControlNamePuzzlePages))
        {
            await next();
        }
        else
        {
            context.Response.Redirect("/home/FeatureDisabled");
            return;
        }
    });
});


app.MapControllerRoute(
    name: "puzzle-catch",
    pattern: "puzzles/{action}",
    defaults: new
    {
        controller = "Puzzles"
    });

app.MapControllerRoute(
    name: "puzzle-default",
    pattern: "puzzles/{*anything}",
    defaults: new
    {
        controller = "Puzzles",
        action = "Index"
    });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
