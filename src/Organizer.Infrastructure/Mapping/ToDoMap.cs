using Organizer.Domain.Entities;
using Organizer.Infrastructure.Mapping.Base;

namespace Organizer.Infrastructure.Mapping
{
    public class ToDoMap : EntityMap<ToDo>
    {
        protected override string TableName => "to_do";
    }
}
