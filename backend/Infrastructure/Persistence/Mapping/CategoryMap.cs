using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("categories");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            Map(x => x.Name).Column("name").Unique().Not.Nullable();
            Map(x => x.Description).Column("description");
        }
    }
}