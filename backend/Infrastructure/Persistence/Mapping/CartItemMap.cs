using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class CartItemMap : ClassMap<CartItem>
    {
        public CartItemMap()
        {
            Table("cart_items");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            References(x => x.Cart).Column("cart_id").Not.Nullable().UniqueKey("UQ_CartItem_CartProduct");
            References(x => x.Product).Column("product_id").Not.Nullable().UniqueKey("UQ_CartItem_CartProduct");
            Map(x => x.Quantity).Column("quantity").Not.Nullable();
            Map(x => x.CreatedAt).Column("created_at").Not.Nullable();
            Map(x => x.UpdatedAt).Column("updated_at").Not.Nullable();
        }
    }
}