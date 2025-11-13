using GoVisit_Project.DAL;
using GoVisit_Project.DAL.Interfaces;
using GoVisit_Project.BusinessLogic;
using GoVisit_Project.BusinessLogic.Interfaces;
using GoVisit_Project.Process.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Register layers with DI
builder.Services.AddSingleton<MongoContext>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<AppointmentHandlers>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
app.Run();
