using Microsoft.EntityFrameworkCore;
using WebApiDemo;
using WebApiDemo.Entities;
using WebApiDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Inject the DbContext.  InMemoryDatabase.
builder.Services.AddDbContext<MyContext>(options => options.UseInMemoryDatabase("Test"));

//Dependency Inject the Service
builder.Services.AddScoped<OrderService>();

//Build the app
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



//Add the endpoints
app.MapGet("/Customers", async (OrderService serviceOrder) =>
{
    return await serviceOrder.GetCustomersAsync();
});

app.MapGet("/Customer/{id}", async (int id, OrderService serviceOrder) =>
{
    return await serviceOrder.GetCustomerAsync(id);
});

//Insert
app.MapPost("/Customer", async (Customer customer, OrderService serviceOrder) =>
{
    return await serviceOrder.InsertCustomerAsync(customer);
});

//Update
app.MapPut("/Customer/{id}", async (Customer customer, OrderService serviceOrder) =>
{
    return await serviceOrder.UpdateCustomer(customer);
});

//Delete
app.MapDelete("/Customer/{id}", async (int id, OrderService serviceOrder) =>
{
    return await serviceOrder.DeleteCustomerAsync(id);
});



app.Run();
