using StudentMgmt.Infrastructure.Data;
using StudentMgmt.Core.Interfaces;
using StudentMgmt.Infrastructure.Repositories;
using StudentMgmt.Application.Services;

var builder = WebApplication.CreateBuilder(args);

//  Add Controllers support 
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind MongoDbSettings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));

// Register Data and Repository Layers
builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<CourseService>();

// Register Application Services
builder.Services.AddScoped<StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  Map Controllers 
app.MapControllers();

app.Run();