using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ????? ???????
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSession(); // ????? ??????
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ????? ???? ??????? ?? ???? ???????
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// ????? ??? Middlewares ??????
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // ?? ??? ???? ???? ??? UseAuthorization

app.UseAuthorization();

// ????? ????????
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();