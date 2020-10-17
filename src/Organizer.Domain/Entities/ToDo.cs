using Organizer.Domain.Entities.Base;

namespace Organizer.Domain.Entities
{
    public class ToDo : Entity
    {
        public string Description { get; private set; }

        public bool IsDone { get; private set; } = false;

        public ToDo(string description)
        {
            Description = description;
        }
    }
}
