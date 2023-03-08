//configure service -- define the services  for my app
using Capstone1.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//define services
builder.Services.AddMvc();
builder.Services.AddDbContext<SweetDBContext>(opt=>
opt.UseSqlServer(builder.Configuration["ConnectionStrings:SweetConn"]));    

builder.Services.AddScoped<ISweetRepository, SweetRepository>();
builder.Services.AddRazorPages();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache(); //for storing info
builder.Services.AddScoped<Cart>(sv => SessionCart.GetCart(sv));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


//configure -- register my middleware components for the request pipeline
var app = builder.Build();

//Css files
app.UseStaticFiles();

//Session
app.UseSession();


//if you want to use routing middleware component
app.UseRouting();

//where is the route or path
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("categorization", "{category}/Page{currentPage}",
new { controller = "Home", action = "Index" });

    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

//Sdata.LoadData(app);

app.Run();
