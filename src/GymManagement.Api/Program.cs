using GymManagement.Api;
using GymManagement.Application;
using GymManagement.Infrastructure;
using GymManagement.Infrastructure.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);
{
    
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
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