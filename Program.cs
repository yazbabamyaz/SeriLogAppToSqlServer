using LogAppGiris.Services.Abstract;
using LogAppGiris.Services.Concrete;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()//Dinamik olarak özellik eklememizi saðlar.
   .CreateLogger();
Log.Logger.Information("Logging is working fineeee.... ");

//builder.Logging.AddSerilog();
builder.Host.UseSerilog();




// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMathService, MathService>();//service classýmýzý register ettik.DI container kullanarak.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
