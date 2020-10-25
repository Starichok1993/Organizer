using Organizer.Domain.Entities.Base;
using System;

namespace Organizer.Domain.Entities
{
    public class DbVersion : Entity
    {
        public string Version { get; private set; }
        public string Description { get; private set; }
        public DateTime DateApplied { get; private set; }

        protected DbVersion()
        {
            
        }
    }
}
