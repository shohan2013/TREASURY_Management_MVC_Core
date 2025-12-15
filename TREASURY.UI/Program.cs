using TREASURY.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TREASURY.UI.Service.CommonService;
using TREASURY.UI.Repository.CommonRepository;
using TREASURY.UI.Service.Login;
using TREASURY.UI.Repository.LoginRepository;
using Microsoft.AspNetCore.Authentication.Cookies;
using TREASURY.UI.Service.MenuService;
using TREASURY.UI.Repository.MenuRepository;

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Http.Features;
using TREASURY.UI.Service.TreasuryService.InterestCalculationService;
using TREASURY.UI.Repository.TreasuryRepository.InterestCalculationRepository;
using TREASURY.UI.Service.TreasuryService.TreasuryReportService;
using TREASURY.UI.Repository.TreasuryRepository.TreasuryReportRepository;
using TREASURY.UI.Service.TreasuryService.LimitFacilityService;
using TREASURY.UI.Repository.TreasuryRepository.LimitFacilityRepository;
using TREASURY.UI.Service.TreasuryService.BankLoanService;
using TREASURY.UI.Repository.TreasuryRepository.BankLoanRepository;
using TREASURY.UI.Service.TreasuryService.SettlementService;
using TREASURY.UI.Repository.TreasuryRepository.SettlementRepository;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<DBSecurityDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBSecurityDbContext")));

builder.Services.Configure<FormOptions>(options => options.ValueCountLimit = 1000000);
//builder.Services.AddTransient<IAgreementLanding, RAgreementLanding>();



builder.Services.AddTransient<ICommon, RCommon>();
builder.Services.AddTransient<ILogin, RLogin>();
builder.Services.AddTransient<IMenu, RMenu>();
builder.Services.AddTransient<IInterestCalculation, RInterestCalculation>();
builder.Services.AddTransient<ITreasuryReport, RTreasuryReport>();
builder.Services.AddTransient<IInterestCalculationApproval, RInterestCalculationApproval>();
builder.Services.AddTransient<ILimitFacility, RLimitFacility>();
builder.Services.AddTransient<IBankLoan, RBankLoan>();
builder.Services.AddTransient<ISettlement, RSettlementRepository>();


builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();


builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 1048576000; // 100 MB, adjust accordingly
});
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 1048576000; // 100 MB
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.Name = "Enroll";
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Forbidden/";
    });
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);  
    options.Cookie.HttpOnly = true;  
    options.Cookie.IsEssential = true;  
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();
