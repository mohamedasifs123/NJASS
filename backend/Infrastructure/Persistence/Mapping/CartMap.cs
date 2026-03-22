using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class CartMap : ClassMap<Cart>
    {
        public CartMap()
        {
            Table("carts");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            References(x => x.User).Column("user_id").Unique().Not.Nullable().Cascade.All();
            Map(x => x.CreatedAt).Column("created_at").Not.Nullable();
            Map(x => x.UpdatedAt).Column("updated_at").Not.Nullable();
        }
    }
}