var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();      // adds all controller classes in the project as services to the app

var app = builder.Build();

//app.MapGet("/", () => "Hii! from dotNETControllersApp!");

app.Run();
