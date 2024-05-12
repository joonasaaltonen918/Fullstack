using EventPlan1.Models.Domain;
using EventPlan1.Repositories.Abstract;
using EventPlan1.Repositories.Implement;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EventPlan1.Models.Domain;
using EventPlan1.Repositories.Abstract;
using EventPlan1.Repositories.Implement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/UserAuthentication/Login";
    options.AccessDeniedPath = "/Event/EventList";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
}
               );
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policy =>
    {
        policy.RequireAssertion(context =>
            (context.User.Identity.IsAuthenticated && context.User.IsInRole("Admin")));
    });
});


builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IEventService, EventService>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders( );



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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Event}/{action=EventList}/{id?}");

app.Run();
