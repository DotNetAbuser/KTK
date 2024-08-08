using Domain.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    var kestrelSection = configuration.GetSection("Kestrel");
    serverOptions.Configure(kestrelSection);
}).UseKestrel();

builder.Services.AddTransient<DbContext, ApplicationDbContext>();
builder.Services.AddDatabase(configuration);

builder.Services.AddUnitOfWork();
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddJwtAuthentication(configuration);
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwagger();
builder.Services.AddControllers();

var app = builder.Build();

#if DEBUG
app.AddSwagger();
#endif

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();