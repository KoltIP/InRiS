using A.Configurations.Cors;
using A.Configurations.Versioning;
using A.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAppCors();

builder.Services.AddAppVersion();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDivisionService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAppCors();

app.UseAuthorization();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
