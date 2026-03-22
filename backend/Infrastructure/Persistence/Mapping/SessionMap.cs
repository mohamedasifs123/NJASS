using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class SessionMap : ClassMap<Session>
    {
        public SessionMap()
        {
            Table("sessions");
            Id(x => x.Id).GeneratedBy.Assigned().Column("id").CustomType("Guid");
            References(x => x.User).Column("user_id").Not.Nullable();
            Map(x => x.Token).Column("token").Unique().Not.Nullable();
            Map(x => x.ExpiresAt).Column("expires_at").Not.Nullable();
            Map(x => x.CreatedAt).Column("created_at").Not.Nullable();
        }
    }
}