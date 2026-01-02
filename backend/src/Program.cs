using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<FoodDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IFoodRepository, FoodRepository>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
var app = builder.Build();
app.UseExceptionHandler("/exception");
if (app.Environment.IsDevelopment())
{
    app.UseCors();
    //app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}
app.MapControllers();
app.Run();