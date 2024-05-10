using System.Globalization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Contexts;
using TeamHost.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")))
    .Configure<IdentityOptions>(opt =>
    {
        opt.Password.RequireDigit = false;
        opt.Password.RequiredLength = 5;
        opt.Password.RequireUppercase = false;
        opt.Password.RequireNonAlphanumeric = false;
    })
    .AddIdentity<User, IdentityRole<int>>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddPersistenceLayer(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var cookieName = "Language";
    var supportedCultures = new[] { "en", "ru", "th" };

    // Получаем язык из куки, если куки не установлен, используем язык по умолчанию
    var culture = context.Request.Cookies.ContainsKey(cookieName)
        ? context.Request.Cookies[cookieName]
        : supportedCultures[0];

    // Проверяем, что выбранный язык является допустимым
    if (!supportedCultures.Contains(culture))
    {
        culture = supportedCultures[0]; // Если выбранный язык недопустим, используем язык по умолчанию
    }

    // Устанавливаем выбранный язык для текущего контекста локализации
    var cultureInfo = new CultureInfo(culture!);
    CultureInfo.CurrentCulture = cultureInfo;
    CultureInfo.CurrentUICulture = cultureInfo;

    // Продолжаем выполнение запроса
    await next();
});
app.UseDeveloperExceptionPage();
 
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area=Home}/{controller=Home}/{action=Index}/{id?}");

app.Run();
