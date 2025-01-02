using Microsoft.EntityFrameworkCore;
using Pastbin.DBContext;
using Pastbin.Endpoints;
using Pastbin.Interfaces;
using Pastbin.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PastebinContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IRecordService, RecordService>();
var app = builder.Build();

app.MapRecordEndpoints();
app.MapFrontendEndpoints();

app.Run();
