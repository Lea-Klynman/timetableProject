using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using TimeTable.Api;
using TimeTable.Core;
using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;
using TimeTable.Core.IService;
using TimeTable.Data;
using TimeTable.Data.Repository;
using TimeTable.Service.EntityService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Service

builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();


//Repository

builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IAvailabilityRepository, AvailabilityRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<ITeacherClassSubjectRepository, TeacherClassSubjectRepository>();
builder.Services.AddScoped<IClassSubjectRepository, ClassSubjectRepository>();

//Data

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-13C4MS2;Initial Catalog=TimeTable;Integrated Security=true");
});


//builder.Services.AddSingleton<DataContext>();
//

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ProfileMapping), typeof(PostModelProfileMapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
