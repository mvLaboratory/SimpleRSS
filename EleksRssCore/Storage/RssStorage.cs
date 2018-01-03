using System;
using System.Data.Entity;
using System.Data.SQLite;

namespace EleksRssCore
{
    public class RssStorage : DbContext, IStorage
    {

        public RssStorage() : base(new SQLiteConnection()
                                {
                                    ConnectionString = new SQLiteConnectionStringBuilder()
                                    {
                                        DataSource = Environment.CurrentDirectory + Properties.Settings.Default.ConnectionString,
                                        ForeignKeys = true
                                    }.ConnectionString
                                }, true)
        {
            Database.SetInitializer<RssStorage>(null);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public override DbSet<TEntity> Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<RssItem> FeedItems { get; set; }
    }
}