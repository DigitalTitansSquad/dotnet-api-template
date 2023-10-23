using DotnetApi.Startup.Extensions;

var (builder, services, configuration) = WebApplication.CreateBuilder(args);
// var executingAssembly = Assembly.GetExecutingAssembly();
// var coreAssembly = typeof(CreateUserCommand).Assembly;

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

services.AddControllers();
// services.AddEndpointsApiExplorer();
services.AddSwagger();
// services.AddMediator(executingAssembly, coreAssembly);
// services.AddMapper(typeof(MappingProfile));
// services.AddCors(configuration);
// services.AddOwnAuthentication(configuration);
// services.AddOwnAuthorization();
// services.AddExceptionHandlers();
// services.AddExceptionHandlersFrom(executingAssembly); //todo: check if this works; this is not the exceptions assembly
// services.AddPostgreSql(configuration);
// services.AddInfrastructureServices();
// services.AddValidators(coreAssembly);
// services.AddHttpContextAccessor();
// services.AddRevolut(configuration);

var (middleware, endpoints, app)
    = builder.Build();

// middleware.UseCors(PolicyNames.AllowOrigin);
middleware.UseSwagger();
middleware.UseSwaggerUI();
// middleware.UseHttpsRedirection();
// middleware.UseRouting();
// middleware.UseAuthentication();
// middleware.UseAuthorization();
// middleware.UseExceptionHandling();
// middleware.UseExceptionLogging();

// endpoints.MapControllers()
//     .RequireAuthorization(BudgetBossApi.Common.Auth.PolicyNames.DefaultPolicy);

app.Run();