using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class PaymentMap : ClassMap<Payment>
    {
        public PaymentMap()
        {
            Table("payments");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            References(x => x.Order).Column("order_id").Unique().Not.Nullable();
            Map(x => x.PaymentDate).Column("payment_date").Not.Nullable();
            Map(x => x.Amount).Column("amount").Not.Nullable();
            Map(x => x.PaymentMethod).Column("payment_method").Not.Nullable();
            Map(x => x.Status).Column("status").Not.Nullable();
            Map(x => x.TransactionId).Column("transaction_id");
            Map(x => x.CreatedAt).Column("created_at").Not.Nullable();
            Map(x => x.UpdatedAt).Column("updated_at").Not.Nullable();
        }
    }
}