using Microsoft.EntityFrameworkCore;
using VerticalSliceDance.Features.DanceStudios.CreateStudio;
using VerticalSliceDance.Features.DanceStudios.DeleteStudio;
using VerticalSliceDance.Features.DanceStudios.GetStudios;
using VerticalSliceDance.Features.Instructors.CreateInstructor;
using VerticalSliceDance.Features.Instructors.GetInstructorsByStudio;
using VerticalSliceDance.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGetStudiosEndpoint();
app.MapCreateStudioEndpoint();
app.MapDeleteStudioEndpoint();
app.MapCreateInstructorEndpoint();
app.MapGetInstructorByStudioEndpoint();

app.Run();