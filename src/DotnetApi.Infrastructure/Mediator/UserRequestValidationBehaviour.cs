using System;
using DotnetApi.Infrastructure.Database;
using FluentValidation;
using MediatR;
using DotnetApi.Infrastructure.Database.Extensions;
using DotnetApi.Common.Exceptions;

namespace DotnetApi.Infrastructure.Mediator
{
    public class UserRequestValidationBehaviour<TRequest, TResponse>(
        DotnetApiDbContext dbContext) :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly DotnetApiDbContext _dbContext = dbContext;

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var isUserRequest = request
            .GetType()
            .GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IUserRequest<>));

            if (!isUserRequest)
                return await next();

            var userRequest = (IUserRequest<TResponse>)request;
            var user = await _dbContext.GetUserOrDefaultAsync(userRequest.UserId) ?? throw BadRequestException.Create($"User {userRequest.UserId} does not exist");
            
            return await next();
        }
    }

}

