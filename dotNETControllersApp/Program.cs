var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();      // adds all controller classes in the project as services to the app

var app = builder.Build();

app.MapControllers();                   // follwowing lines of code do the exact same job as this MapControllers() method does
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.MapGet("/", () => "Hii! from dotNETControllersApp!");

app.Run();
