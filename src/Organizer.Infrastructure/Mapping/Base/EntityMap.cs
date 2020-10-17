using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.Infrastructure.Mapping.Base
{
    public abstract class EntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
            where TEntity : class, IEntity<int>
    {
        protected abstract string TableName { get; }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("int").IsRequired();
        }
    }
}
