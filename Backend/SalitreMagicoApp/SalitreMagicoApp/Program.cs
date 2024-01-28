using MySql.Data.MySqlClient;
using SalitreMagico.Data;
using SalitreMagico.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Coneccion a la base de datos
var mySQLConfiguration = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySQLConnection"));
builder.Services.AddSingleton(mySQLConfiguration);

builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySQLConnection")));

builder.Services.AddScoped<IActtraction, AttractionRepository>();
builder.Services.AddScoped<IClient, ClientRepository>();
builder.Services.AddScoped<IContactChildren, ContactChildrenRepository>();
builder.Services.AddScoped<ICostTicket, CostoTicketRepository>();
builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<IFunctions, FunctionRepository>();
builder.Services.AddScoped<IJobPosition, JobPositionRepository>();
builder.Services.AddScoped<IVisitsStatus, VisitStatusRepository>();
builder.Services.AddScoped<IStatusAttraction, StatusAttractionRepository>();
builder.Services.AddScoped<ITicket, TicketRepository>();
builder.Services.AddScoped<ITicketStation, TicketStationRepository>();
builder.Services.AddScoped<IUsser, UsserRepository>();
builder.Services.AddScoped<IUsserAttraction, UsserAttractionRepository>();




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
