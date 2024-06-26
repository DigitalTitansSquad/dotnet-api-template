using AutoMapper;
using DigitalTitans.DotnetApi.Core.Models;

namespace DigitalTitans.DotnetApi.Core.Features.Users.GetUsers;

public class GetUsersMappingProfile : Profile
{
    public GetUsersMappingProfile()
    {
        CreateMap<UserEntity, GetUsersReadModel>();
    }
}