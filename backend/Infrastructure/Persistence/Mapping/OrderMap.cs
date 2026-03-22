using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("orders");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            References(x => x.User).Column("user_id").Not.Nullable();
            Map(x => x.OrderDate).Column("order_date").Not.Nullable();
            Map(x => x.TotalAmount).Column("total_amount").Not.Nullable();
            Map(x => x.Status).Column("status").Not.Nullable();
            Map(x => x.CreatedAt).Column("created_at").Not.Nullable();
            Map(x => x.UpdatedAt).Column("updated_at").Not.Nullable();
        }
    }
}