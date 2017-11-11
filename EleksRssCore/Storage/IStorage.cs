using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EleksRssCore
{
    public interface IStorage
    {
        DbSet<Category> Categories { get; set; }
        DbSet<RssItem> FeedItems { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry Entry(object entity);
        void Dispose();
        int SaveChanges();
    }
}
