using FluentNHibernate.Mapping;
using Domain.Entities;

namespace Infrastructure.Persistence.Mapping
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");

            Id(x => x.Id).GeneratedBy.Guid();

            Map(x => x.Username);
            Map(x => x.PasswordHash);
        }
    }
}