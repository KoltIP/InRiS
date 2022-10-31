using A;
using A.Configurations.Cors;
using A.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAppCors();

builder.Services.AddCors();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDivisionService();

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

app.UseCors(builder => builder.WithOrigins("http://localhost:5031")
                        .AllowAnyHeader()
                        .AllowAnyMethod());

//app.UseAppCors();

app.MapControllers();

app.Run();
