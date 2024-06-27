using AutoMapper;
using DigitalTitans.DotnetApi.Core.Models;

namespace DigitalTitans.DotnetApi.Core.Features.Users.CreateUser;

public class CreateUserMappingProfile : Profile
{
    public CreateUserMappingProfile()
    {
        CreateMap<CreateUserCommand, UserEntity>();
    }
}
