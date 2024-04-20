using HomeAppliances.Business.Abstract;
using HomeAppliances.Business.Concrete;
using HomeAppliances.Data.Abstract;
using HomeAppliances.Data.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Configurations
#region Services
builder.Services.AddScoped<EfCoreContext>();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(EfCoreGenericRepository< Product,EfCoreContext>));

builder.Services.AddScoped(typeof(ICardDal), typeof(EfCoreCardDal));
builder.Services.AddScoped(typeof(IBrandDal), typeof(EfCoreBrandDal));
builder.Services.AddScoped(typeof(IProductDal), typeof(EfCoreProductDal));
builder.Services.AddScoped(typeof(IOrderDal), typeof(EfCoreOrderDal));
builder.Services.AddScoped(typeof(ICategoryDal), typeof(EfCoreCategoryDal));

builder.Services.AddScoped(typeof(ICardService), typeof(CardManager));
builder.Services.AddScoped(typeof(IBrandService), typeof(BrandManager));
builder.Services.AddScoped(typeof(IProductService), typeof(ProductManager));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderManager));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryManager));
#endregion

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
