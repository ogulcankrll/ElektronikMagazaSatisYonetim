using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstcart;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Context;
using EntityLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
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

// Generic servisler
builder.Services.AddScoped<IGenericService<Rol>, GenericManager<Rol>>();
builder.Services.AddScoped<IGenericDal<Rol>, GenericRepository<Rol>>();

builder.Services.AddScoped<IGenericService<TeslimatTipi>, GenericManager<TeslimatTipi>>();
builder.Services.AddScoped<IGenericDal<TeslimatTipi>, GenericRepository<TeslimatTipi>>();

builder.Services.AddScoped<IGenericService<SiparisDurumu>, GenericManager<SiparisDurumu>>();
builder.Services.AddScoped<IGenericDal<SiparisDurumu>, GenericRepository<SiparisDurumu>>();







builder.Services.AddDbContext<MyContext>();
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
