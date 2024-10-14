using AutoMapper;
using Fiap.Api.Entrega.Data.Contexts;
using Fiap.Api.Entrega.Data.Repository;
using Fiap.Api.Entrega.Model;
using Fiap.Api.Entrega.Services;
using Fiap.Api.Entrega.ViewModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Configuracao do DB
var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    opt => opt.UseOracle(connectionString).EnableSensitiveDataLogging(true));
#endregion


#region Repository
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
#endregion
#region Services
builder.Services.AddScoped<IAgendaService, AgendaService>();
#endregion


#region AutoMapper
    var mapperConfig = new AutoMapper.MapperConfiguration(c => {
    // Permite que coleções nulas sejam mapeadas
    c.AllowNullCollections = true;
    // Permite que valores de destino nulos sejam mapeados
    c.AllowNullDestinationValues = true;

    c.CreateMap<AgendaModel, AgendaViewModel>();

    c.CreateMap<AgendaViewModel, AgendaModel>();
    c.CreateMap<AgendaCreateViewModel, AgendaModel>();
    c.CreateMap<AgendaUpdateViewModel, AgendaModel>();
});



IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion




// Add services to the container.

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
