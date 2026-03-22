using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class ProductCategoryMap : ClassMap<Product>
    {
        public ProductCategoryMap()
        {
            Table("product_categories");
            CompositeId()
                .KeyProperty(x => x.ProductId, "product_id")
                .KeyProperty(x => x.CategoryId, "category_id");

            References(x => x.Product).Column("product_id").Not.Insert().Not.Update();
            References(x => x.Category).Column("category_id").Not.Insert().Not.Update();
        }
    }
}
