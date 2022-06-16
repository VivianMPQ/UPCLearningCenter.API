using Microsoft.EntityFrameworkCore;
using UPCLearningCenter.API.Learning.Domain.Repositories;
using UPCLearningCenter.API.Learning.Domain.Services;
using UPCLearningCenter.API.Learning.Mapping;
using UPCLearningCenter.API.Learning.Persistence.Contexts;
using UPCLearningCenter.API.Learning.Persistence.Repositories;
using UPCLearningCenter.API.Learning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//add database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseMySQL(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// Add lowercase routes -> en minuscula
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//dependency injection configuration -> repository and service
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
builder.Services.AddScoped<ITutorialService, TutorialService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//automapper configuration -> poner los profile que hemos creado
builder.Services.AddAutoMapper(typeof(ModelToResourceProfile), typeof(ResourceToModelProfile));

var app = builder.Build();

//validation for ensuring database objects are created
//validación para garantizar que se creen objetos de base de datos
using (var scope =app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}


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