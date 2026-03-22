using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("products");

Id(x => x.Id)
    .GeneratedBy.Assigned().Column("id")
                .CustomType("Guid"); // 
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.CreatedAt);
            Map(x => x.UpdatedAt);
            Map(x => x.IsDeleted);
        }
    }
}