using ElasticProject.Data.Domain;
using Nest;

namespace ElasticProject.Data.Infrastructure.Mapping
{
    public static class Mapping
    {
        public static CreateIndexDescriptor CitiesMapping(
            this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<Cities>(
                i => i.Properties(property =>
                    property
                        .Keyword(keyword => keyword.Name(name => name.Id))
                        .Text(t => t.Name(name => name.City))
                        .Text(t => t.Name(name => name.Region))
                        .Number(t => t.Name(name => name.Population))
                        .Date(t => t.Name(name => name.CreatedDate)))
                );
        }
    }
}
