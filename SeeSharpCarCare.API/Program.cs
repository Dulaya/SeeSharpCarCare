using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.Data;
using SeeSharpCarCare.API.Models;
using SeeSharpCarCare.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
   options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(); 

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddScoped<IVehicleService, VehicleService>(); 
builder.Services.AddScoped<IRepository<Vehicle>, Repository<Vehicle>>(); 

builder.Services.AddScoped<ITechnicianService, TechnicianService>(); 
builder.Services.AddScoped<IRepository<Technician>, Repository<Technician>>(); 

builder.Services.AddScoped<IWorkOrderService, WorkOrderService>(); 
builder.Services.AddScoped<IRepository<WorkOrder>, Repository<WorkOrder>>(); 

builder.Services.AddScoped<ITechWorkOrderService, TechWorkOrderService>(); 
builder.Services.AddScoped<ITechWorkOrderRepository, TechWorkOrderRepository>(); 

builder.Services.AddScoped<IWorkOrderRepo, WorkOrderRepo>(); 

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Replace with your frontend URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(); 
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("MyAllowSpecificOrigins");


app.Run();