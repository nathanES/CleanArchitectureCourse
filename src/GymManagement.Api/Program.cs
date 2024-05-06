using GymManagement.Application;
using GymManagement.Infrastructure;
using GymManagement.Infrastructure.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddProblemDetails();//Add dependencies needed for app.UseExceptionHandler
    builder.Services.AddHttpContextAccessor();
    
    builder.Services.AddApplication()
        .AddInfrastructure();
}

var app = builder.Build();
{
    app.UseExceptionHandler(); //Add in the request pipeline a middleware which rap everything in a try-catch
    app.AddInfrastructureMiddleware();
    
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}