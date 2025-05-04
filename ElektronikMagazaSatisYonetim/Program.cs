using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstcart;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

// Session ekleniyor
builder.Services.AddSession(); 

// Servisler
builder.Services.AddScoped<IUrunServis, UrunManager>();
builder.Services.AddScoped<IUrunDAL, EFUrunDAL>();

builder.Services.AddScoped<IKategoriServis, KategoriManager>();
builder.Services.AddScoped<IKategoriDAL, EFKategoriDAL>();

builder.Services.AddScoped<IMarkaServis, MarkaManager>();
builder.Services.AddScoped<IMarkaDAL, EFMarkaDAL>();

builder.Services.AddScoped<IMusteriServis, MusteriManager>();
builder.Services.AddScoped<IMusteriDAL, EFMusteriDAL>();

builder.Services.AddScoped<IKargoFirmaServis, KargoFirmaManager>();
builder.Services.AddScoped<IKargoFirmaDAL, EFKargoFirmaDAL>();

builder.Services.AddScoped<IUrunVaryasyonServis, UrunVaryasyonManager>();
builder.Services.AddScoped<IUrunVaryasyonDAL, EFUrunVaryasyonDAL>();

builder.Services.AddScoped<IPersonelServis, PersonelManager>();
builder.Services.AddScoped<IPersonelDAL, EFPersonelDAL>();

// Generic servisler
builder.Services.AddScoped<IGenericService<Rol>, GenericManager<Rol>>();
builder.Services.AddScoped<IGenericDal<Rol>, GenericRepository<Rol>>();

builder.Services.AddScoped<IGenericService<TeslimatTipi>, GenericManager<TeslimatTipi>>();
builder.Services.AddScoped<IGenericDal<TeslimatTipi>, GenericRepository<TeslimatTipi>>();

builder.Services.AddScoped<IGenericService<SiparisDurumu>, GenericManager<SiparisDurumu>>();
builder.Services.AddScoped<IGenericDal<SiparisDurumu>, GenericRepository<SiparisDurumu>>();

// Kimlik doðrulama
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Giris/Giris";
        opt.AccessDeniedPath = "/Giris/ErisimYasak";
    });

builder.Services.AddDbContext<MyContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseSession(); 
app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Giris}/{action=Giris}/{id?}"); 

app.Run();
