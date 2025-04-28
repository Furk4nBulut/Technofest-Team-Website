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
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
// IAboutService ve AboutService ekleniyor.
builder.Services.AddScoped<IAboutService, AboutService>();
// ITeamService ve TeamService kaydını ekleyin
builder.Services.AddScoped<ITeamService, TeamService>();
// ISponsorService ve SponsorService kaydını ekleyin
builder.Services.AddScoped<ISponsorService, SponsorService>();


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
app.UseAuthentication();  // Kullanıcı doğrulaması önce yapılmalı
app.UseAuthorization();   // Yetkilendirme sonra yapılmalı

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Kullanıcıyı eklemek için sadece bir kez çalışacak kod
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var user = await userManager.FindByEmailAsync("admin@example.com");

    // Eğer admin kullanıcısı yoksa
    if (user == null)
    {
        user = new User
        {
            UserName = "admin@example.com",
            Email = "admin@example.com"
        };

        var result = await userManager.CreateAsync(user, "Admin123!"); // Parola "admin"
        if (result.Succeeded)
        {
            // Admin rolünü ekleyelim, önceden var mı kontrol edelim
            var roleExist = await roleManager.RoleExistsAsync("Admin");
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

app.Run();
