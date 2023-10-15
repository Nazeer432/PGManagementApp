using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IHostelRepository, HostelRepository>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomBedRepository, RoomBedRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<ITenantBedMappingRepository, TenantBedMappingRepository>();
builder.Services.AddScoped<IFeeDetailsRepository, FeeDetailsRepository>();
builder.Services.AddScoped<IDailyWagesRepository, DailyWagesRepository>();

var connectionString = builder.Configuration.GetConnectionString("Scaffold-DbContext");

builder.Services.AddDbContext<HostelDBContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

});


builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<HostelDBContext>();
builder.Services.AddRazorPages();
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

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Accounts}/{action=Login}/{id?}");

//app.MapControllerRoute(
//    name: "userProfiles",
//    pattern: "{controller=UserProfiles}/{action=Index}/{id?}");

//app.UseStatusCodePages(async context =>
//{
//    if (context.HttpContext.Response.StatusCode == 401)
//    {
//        context.HttpContext.Response.Redirect("/Login/UserLogin");
//    }
//});


app.Run();
