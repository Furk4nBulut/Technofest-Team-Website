using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Techonefest_Team_Website.Data;
using Techonefest_Team_Website.Models;
using Techonefest_Team_Website.Services;
using Techonefest_Team_Website.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// SQLite veritabanı bağlantısı
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity yapılandırması
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

// IAuthenticationService için doğru implementasyon
builder.Services.AddScoped<IAuthenticationService, Techonefest_Team_Website.Services.AuthenticationService>();

// MVC yapılandırması
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Middleware'ler
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Program.cs içinde, app.Run() öncesine ekleyin (yalnızca bir kez çalıştırın)
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var user = new User { UserName = "admin@mail.com", Email = "admin@example.com", FullName = "Admin User", RegistrationDate = DateTime.UtcNow };
    await userManager.CreateAsync(user, "admin");
}

app.Run();