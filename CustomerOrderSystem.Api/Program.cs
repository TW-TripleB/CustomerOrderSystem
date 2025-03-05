using CustomerOrderSystem.Domain.Repositories;
using CustomerOrderSystem.Infrastructure.Persistence;
using CustomerOrderSystem.Application.Services;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var services = builder.Services;

// 註冊應用服務
services.AddSingleton<IOrderRepository, InMemoryOrderRepository>();
services.AddScoped<OrderService>();

// 設定 Controller
services.AddControllers();

var app = builder.Build();

// 啟用 Controller
app.MapControllers();
app.Run();
