using Swashbuckle.AspNetCore.Annotations;

namespace DigitalTitans.DotnetApi.Core.Features.Users;

public class UserSwaggerOperationAttribute : SwaggerOperationAttribute
{
    private const string Tag = "Users";
    public UserSwaggerOperationAttribute() : base()
    {
        Tags = [Tag];
    }
}
