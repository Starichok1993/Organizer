using Organizer.Domain.Entities;
using Organizer.Infrastructure.Mapping.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Infrastructure.Mapping
{
    public class DbVersionMap : EntityMap<DbVersion>
    {
        protected override string TableName => "db_version";
    }
}
