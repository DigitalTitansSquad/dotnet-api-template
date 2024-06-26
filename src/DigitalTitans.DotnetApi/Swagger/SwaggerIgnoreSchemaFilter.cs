using DigitalTitans.DotnetApi.Core.Common.Api;
using DigitalTitans.DotnetApi.Core.Common.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DigitalTitans.DotnetApi.Swagger;

public class SwaggerIgnoreSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var type = context.Type;

        if (!schema.Properties.Any())
            return;

        var excludedProperties = type
            .GetProperties()
            .Where(property => property.GetCustomAttributes(typeof(SwaggerIgnoreAttribute), true).Any())
            .ToList();

        if (!excludedProperties.Any())
            return;

        foreach (var property in excludedProperties)
        {
            var camelCasePropertyName = property.Name.ToCamelCase();
            if (schema.Properties.ContainsKey(camelCasePropertyName))
                schema.Properties.Remove(camelCasePropertyName);
        }
    }
}