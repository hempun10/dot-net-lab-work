using Microsoft.EntityFrameworkCore;
using myapp.Data;
using myapp.Repositories;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("NeonConnection");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NeonConnection")));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IHotelRepository,HotelRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    Console.WriteLine("In Development Mode");
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

