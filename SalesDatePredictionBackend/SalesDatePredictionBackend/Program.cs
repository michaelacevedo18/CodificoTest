using Microsoft.EntityFrameworkCore;
using SalesDatePredictionBusinnesLogic.Contracts;
using SalesDatePredictionBusinnesLogic.Implementations;
using SalesDatePredictionDataAccess;

var builder = WebApplication.CreateBuilder(args);

string ServerDb = builder.Configuration["ConnectionStrings:ServerDb"];
string NameDb = builder.Configuration["ConnectionStrings:NameDb"];
string UserDb = builder.Configuration["ConnectionStrings:UserDb"];
string pass = builder.Configuration["ConnectionStrings:DbPassword"];


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        $"Server={ServerDb};database={NameDb};User ID={UserDb};Password={pass};MultipleActiveResultSets=True;Encrypt=False;"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IShipperRepository, ShipperRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.WithOrigins("http://localhost:4200") // Dirección de tu app Angular
           .AllowAnyMethod()
           .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
