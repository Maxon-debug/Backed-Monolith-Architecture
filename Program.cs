using MaxonEventManagement.Data;
using MaxonEventManagement.Extensions;
using MaxonEventManagement.Services;
using MaxonEventManagement.Services.IService;
using MaxonEventManagement.Servuces.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Registered EventServices
builder.Services.AddScoped<IEvent, EventService>();

//Registered TicketServices
builder.Services.AddScoped<ITicket, TicketService>();

//Registered the UserService
builder.Services.AddScoped<IUser, UserService>();

//register JwtServices
builder.Services.AddScoped<IJwt,JwtService>();

builder.AddAuth();
builder.AddAdminPolicy();
builder.AddSwaggenGenExtension();


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
