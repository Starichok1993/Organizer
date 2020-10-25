namespace Organizer.Domain.Entities.Base
{

    public interface IEntity
    {
        object[] GetKeys();

    }

    public interface IEntity <TKey> : IEntity
    {
        TKey Id { get; }

    }

    public abstract class Entity<TKey> : IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }

        protected Entity()
        { 
        }

        protected Entity(TKey id)
        {
            Id = id;
        }

        public virtual object[] GetKeys()
        {
            return new object[] { Id };
        }
                              
    }

    public abstract class Entity : Entity<int>
    {
        
    }
}
