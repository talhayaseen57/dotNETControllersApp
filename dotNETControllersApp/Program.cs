var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();      // adds all controller classes in the project as services to the app

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();                   // following lines of code do the exact same job as this MapControllers() method does
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.MapGet("/", () => "Hii! from dotNETControllersApp!");

app.Run();
