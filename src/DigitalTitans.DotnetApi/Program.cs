using DigitalTitans.DotnetApi.Startup.Extensions;
using DigitalTitans.DotnetApi.Swagger.Extensions;
using DigitalTitans.DotnetApi.Infrastructure.ExceptionHandling.Extensions;
using DigitalTitans.DotnetApi.Infrastructure.Services.Extensions;
using DigitalTitans.DotnetApi.Infrastructure.Mediator.Extensions;
using DigitalTitans.DotnetApi.Infrastructure.Database.Extensions;
using DigitalTitans.DotnetApi.Infrastructure.FluentValidation.Extensions;
using DigitalTitans.DotnetApi.Authorization.Extensions;
using DigitalTitans.DotnetApi.Authentication.Extensions;
using DigitalTitans.DotnetApi.Core.Features.Users;
using DigitalTitans.DotnetApi.Core.Features.Users.CreateUser;
using DigitalTitans.DotnetApi.Cors;
using System.Reflection;


var (builder, services, configuration) = WebApplication.CreateBuilder(args);
var executingAssembly = Assembly.GetExecutingAssembly();
var coreAssembly = typeof(CreateUserCommand).Assembly;

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwagger();
services.AddMediator(executingAssembly, coreAssembly);
services.AddAutoMapper(executingAssembly, coreAssembly);
services.AddCors(configuration);
services.AddOwnAuthentication(configuration);
services.AddOwnAuthorization();
services.AddExceptionHandlers();
services.AddExceptionHandlersFrom(executingAssembly); 
services.AddPostgreSql(configuration);
services.AddInfrastructureServices();
services.AddValidators(coreAssembly);
services.AddHttpContextAccessor();

var (middleware, endpoints, app)
    = builder.Build();

middleware.UseCors(PolicyNames.AllowOrigin);
middleware.UseSwagger();
middleware.UseSwaggerUI();
middleware.UseHttpsRedirection();
middleware.UseRouting();
middleware.UseAuthentication();
middleware.UseAuthorization();
middleware.UseExceptionHandling();
middleware.UseExceptionLogging();

endpoints.AddUserEndpoints();

if (app.Environment.IsEnvironment("Local") || 
    app.Environment.IsDevelopment() || 
    app.Environment.IsEnvironment("IntegrationTest"))
{
    app.ApplyMigrations();
}

app.Run();

public partial class Program { }