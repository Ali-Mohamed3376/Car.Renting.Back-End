using Car.Renting.BL;
using Car.Renting.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Default Services

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region CORS Policy

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

#endregion

#region Database Services

builder.Services.AddDbContext<CarRentingContext>(options => 
                    options.UseSqlServer(@"Server=DESKTOP-35F9698\SQLEXPRESS;Database=CarRentalSystemDB;Trusted_Connection=true;Encrypt=false"));

#endregion

#region Repos Services

builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo >();
builder.Services.AddScoped<IBookingRepo, BookingRepo>();

#endregion

#region Managers Services

builder.Services.AddScoped<ICarManager, CarManager>();
builder.Services.AddScoped<ICustomerManager, CustomerManager>();
builder.Services.AddScoped<IBookingCarsManager, BookingCarsManager>();

#endregion

var app = builder.Build();

#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
