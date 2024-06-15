using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using QuestionBank.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<HutechQuestionBank>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<CustomUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HutechQuestionBank>().AddDefaultTokenProviders().AddDefaultUI();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Delete>();
//builder.Services.AddScoped<DeThiDetail>();
builder.Services.AddScoped<MailSender>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseSession();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "admin",
        pattern: "{area:exists}/{controller=ACauHoi}/{action=Index}/{id?}");
    //endpoints.MapControllerRoute(
    //    name: "matrix",
    //    pattern: "{area:exists}/{controller=MaTran}/{action=Index}/{id?}",
    //    defaults: new {controller = "Matran", action ="Index"}
    //    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapRazorPages();

app.Run();
