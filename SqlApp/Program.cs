using SqlApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddTransient <CourseService> ();
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => {
     endpoints.MapControllerRoute(name: "default", pattern: "{controller=Course}/{action=Index}/{id?}");
});

app.Run();
