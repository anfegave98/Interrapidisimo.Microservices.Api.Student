using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Interrapidisimo.Microservices.Api.Student.Logic.Enrollment.Services;
using Interrapidisimo.Microservices.Api.Student.Logic.Student.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StudentDb"),
        b => b.MigrationsAssembly("Interrapidisimo.Microservices.Api.Student.EntityFramework")
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
    db.Database.Migrate();
}

app.Run();
