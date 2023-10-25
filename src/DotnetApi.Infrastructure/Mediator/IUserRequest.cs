using System;
using MediatR;

namespace DotnetApi.Infrastructure.Mediator
{
    public interface IUserRequest : IUserRequest<Unit> { }

    public interface IUserRequest<T> : IRequest<T>
    {
        string UserId { get; set; }
    }

    public interface IUserResourceRequest : IUserRequest
    {
        string Id { get; set; }
    }

    public interface IUserResourceRequest<T> : IUserRequest<T>
    {
        string Id { get; set; }
    }
}

