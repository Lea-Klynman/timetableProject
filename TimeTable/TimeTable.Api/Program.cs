using TimeTable.Core.Entity;
using TimeTable.Core.IRepository;
using TimeTable.Core.IService;
using TimeTable.Data;
using TimeTable.Data.Repository;
using TimeTable.Service.EntityService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Service
builder.Services.AddScoped<IGenericService<TeacherEntity>, TeacherService>();
builder.Services.AddScoped<IGenericService<ClassEntity>, ClassService>();
builder.Services.AddScoped<IGenericService<AvailabilityEntity>, AvailabilityService>();
builder.Services.AddScoped<IGenericService<SubjectEntity>, SubjectService>();
//Repository
builder.Services.AddScoped<IGenericRepository<SubjectEntity>, SubjectRepository>();
builder.Services.AddScoped<IGenericRepository<ClassEntity>, ClassRepository>();
builder.Services.AddScoped<IGenericRepository<AvailabilityEntity>, AvailabilityRepository>();
builder.Services.AddScoped<IGenericRepository<TeacherEntity>, TeacherRepository>();
//Data
builder.Services.AddSingleton<DataContext>();
//
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

app.UseAuthorization();

app.MapControllers();

app.Run();
