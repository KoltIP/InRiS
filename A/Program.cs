using A;
using A.Configurations.Cors;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppCors();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



var services = builder.Services;


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.UseAppCors();

app.MapControllers();

app.Run();
