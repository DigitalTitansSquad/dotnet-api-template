using AutoMapper;
using DigitalTitans.DotnetApi.Core.Models;

namespace DigitalTitans.DotnetApi.Core.Features.CreateUser;

public class CreateUserMappingProfile : Profile
{
    public CreateUserMappingProfile()
    {
        CreateMap<CreateUserCommand, UserEntity>();
    }
}
