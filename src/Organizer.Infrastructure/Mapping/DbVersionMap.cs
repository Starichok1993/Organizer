using Organizer.Domain.Entities;
using Organizer.Infrastructure.Mapping.Base;

namespace Organizer.Infrastructure.Mapping
{
    public class DbVersionMap : EntityMap<DbVersion>
    {
        protected override string TableName => "db_version";
    }
}
