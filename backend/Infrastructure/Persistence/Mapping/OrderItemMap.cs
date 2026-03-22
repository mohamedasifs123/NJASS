using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class OrderItemMap : ClassMap<OrderItem>
    {
        public OrderItemMap()
        {
            Table("order_items");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            References(x => x.Order).Column("order_id").Not.Nullable().UniqueKey("UQ_OrderItem_OrderProduct");
            References(x => x.Product).Column("product_id").Not.Nullable().UniqueKey("UQ_OrderItem_OrderProduct");
            Map(x => x.Quantity).Column("quantity").Not.Nullable();
            Map(x => x.UnitPrice).Column("unit_price").Not.Nullable();
        }
    }
}