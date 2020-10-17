using Organizer.Domain.Entities.Base;

namespace Organizer.Domain.Entities
{
    public class ToDo : Entity
    {
        public string Description { get; private set; }

        public bool IsDone { get; private set; }

        public ToDo(string description)
        {
            Description = description;
        }

        public void Update(string description, bool isDone)
        {
            Description = description;
            IsDone = isDone;
        }
    }
}
