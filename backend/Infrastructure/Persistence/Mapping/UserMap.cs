using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");

Id(x => x.Id)
    .GeneratedBy.Assigned().Column("id")
                .CustomType("Guid"); // ✅ IMPORTANT
            Map(x => x.Username);
            Map(x => x.PasswordHash);
            Map(x => x.CreatedAt);
            Map(x => x.UpdatedAt);
            Map(x => x.IsDeleted);
        }
    }
}