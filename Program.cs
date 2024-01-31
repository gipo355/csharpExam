using Controllers.Animals;
using Data;
using Microsoft.AspNetCore.Identity;
using Models.User;

var builder = WebApplication.CreateBuilder(args);

// ##### Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddOutputCache();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<UserDbContext>();

// var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
// builder.Services.AddCors(options =>
// {
//   options.AddPolicy(
//     name: myAllowSpecificOrigins,
//     builder =>
//     {
//       builder.WithOrigins("http://example.com", "http://www.contoso.com");
//     }
//   );
// });

// builder.Services.AddSession(options =>
// {
//   options.Cookie.Name = ".AdventureWorks.Session";
//   options.IdleTimeout = TimeSpan.FromSeconds(10);
//   options.Cookie.IsEssential = true;
// });

var app = builder.Build();

// ##### Acivate Middlewere

// app.UseSession();
// app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseOutputCache();

// ##### Map endpoints

app.MapGroup("/api/v1/animals").MapAnimalsApi().WithOpenApi();

app.Run();
