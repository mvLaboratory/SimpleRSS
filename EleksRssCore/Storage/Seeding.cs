using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksRssCore
{
    class Seeding
    {
        internal static void Go(RssStorage context)
        {
            SeedCategories(context);
        }

        private static void SeedCategories(RssStorage context)
        {
            if (context.Categories.SingleOrDefault(_ => _.Id == 1) == null)
            {
                Category defaultCategory = new Category("default", "");
                context.Categories.Add(defaultCategory);
                context.SaveChanges();
            }
        }
    }
}
