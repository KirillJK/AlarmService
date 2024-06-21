using AlarmService.Api.Services;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IAlarmService, AlarmService.Api.Services.AlarmService>();
builder.Services.AddFastEndpoints();
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");
app.UseFastEndpoints();
app.Run();
