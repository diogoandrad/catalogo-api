using Catalogo.Application.PessoaService.Service;
using Catalogo.Application.CidadeService.Service;
using Catalogo.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<ICidadeService, CidadeService>();

builder.Services.AddDbContext<BaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(option => option.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<BaseContext>();
    dataContext.Database.Migrate();
}

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
