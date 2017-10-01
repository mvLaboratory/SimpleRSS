using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksRssCore
{ 
    class Initializer : CreateDatabaseIfNotExists<RssStorage>
    {

        protected override void Seed(RssStorage context)
        {
            Seeding.Go(context);
        }
    }
}
