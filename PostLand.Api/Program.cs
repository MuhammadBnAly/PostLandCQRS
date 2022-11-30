
using PostLand.Application;
using PostLand.Persistance;


var builder = WebApplication.CreateBuilder(args);
// add Configuration
var config = builder.Configuration;
// adding Persisterence Container
builder.Services.AddPersistenceService(config);
// adding Application Container
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    