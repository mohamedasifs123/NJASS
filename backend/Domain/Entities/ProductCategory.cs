using System;

namespace Domain.Entities
{
    public class ProductCategory
    {
        public virtual Guid ProductId { get; set; }
        public virtual Guid CategoryId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;

        // Composite ID for NHibernate
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ProductCategory other = (ProductCategory)obj;
            return ProductId == other.ProductId && CategoryId == other.CategoryId;
        }

        public override int GetHashCode() => HashCode.Combine(ProductId, CategoryId);
    }
}
