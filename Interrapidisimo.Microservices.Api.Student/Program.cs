using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.EntityFramework;
using Interrapidisimo.Microservices.Api.Student.Logic.Enrollment.Logic;
using Interrapidisimo.Microservices.Api.Student.Logic.Student.Logic;
using Interrapidisimo.Microservices.Api.Student.Logic.Teacher.Logic;
using Interrapidisimo.Microservices.Api.Subject.Logic.Subject.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

/// Dependency Injection
builder.Services.AddScoped<IStudentLogic, StudentLogic>();
builder.Services.AddScoped<IEnrollmentLogic, EnrollmentLogic>();
builder.Services.AddScoped<ISubjectLogic, SubjectLogic>();
builder.Services.AddScoped<ITeacherLogic, TeacherLogic>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// Database Context
builder.Services.AddDbContext<StudentDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("StudentDb"),
        b => b.MigrationsAssembly("Interrapidisimo.Microservices.Api.Student.EntityFramework")
    )
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StudentDbContext>();
    db.Database.Migrate();
}

app.Run();
