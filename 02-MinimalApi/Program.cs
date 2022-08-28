using _02_MinimalApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//We need to allow ApiExplorer to use Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<AdventureWorksLT2019Context>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "Hello World!");
//Get all Customers
app.MapGet("/Customer",async (AdventureWorksLT2019Context context) =>
{
	//using (var context = new AdventureWorksLT2019Context())
	//{
	//	return context.Customers.ToList();
	//}
	//The same but with dependency injection
	return await context.Customers.ToListAsync();
});

//app.MapGet("/Customer/{id}",async (int id, AdventureWorksLT2019Context context) =>
//{
//	var customer = await context.Customers.FindAsync(id);

//	return customer != null ? Results.Ok : Results.NotFound();
//});

app.MapPost("/post", () =>
{
	//some insert
});
app.Run();
