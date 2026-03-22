using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("products");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.Name);
            Map(x => x.Price);
        }
    }
}