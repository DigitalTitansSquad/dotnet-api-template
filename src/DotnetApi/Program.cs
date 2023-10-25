using DotnetApi.Startup.Extensions;
using DotnetApi.Swagger.Extensions;
using DotnetApi.Infrastructure.ExceptionHandling.Extensions;
using DotnetApi.Infrastructure.Services.Extensions;
using DotnetApi.Infrastructure.Mediator.Extensions;
using DotnetApi.Infrastructure.Database.Extensions;
using DotnetApi.Infrastructure.FluentValidation.Extensions;
using DotnetApi.Authorization.Extensions;
using DotnetApi.Authentication.Extensions;
using DotnetApi.Core.Features.CreateUser;
using DotnetApi.Cors;
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

endpoints.MapControllers()
    .RequireAuthorization(DotnetApi.Common.Auth.PolicyNames.DefaultPolicy);

app.Run();