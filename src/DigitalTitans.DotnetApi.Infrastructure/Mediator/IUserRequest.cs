using System;
using MediatR;

namespace DigitalTitans.DotnetApi.Infrastructure.Mediator
{
    public interface IUserRequest : IUserRequest<Unit> { }

    public interface IUserRequest<T> : IRequest<T>
    {
        long UserId { get; set; }
    }

    public interface IUserResourceRequest : IUserRequest
    {
        long Id { get; set; }
    }

    public interface IUserResourceRequest<T> : IUserRequest<T>
    {
        long Id { get; set; }
    }
}

