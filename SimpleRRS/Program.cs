using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace SimpleRRS
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://www.upwork.com/ab/feed/jobs/rss?subcategory2=game_development&sort=renew_time_int+desc&api_params=1&q=&securityToken=de8019fa5e3e0eb70d564fddb76793459d9cc6a3e2c6cb2641c25f651825ed18c00c836e25612cefd9790ce91dbd0eff7968ebbe03c5de88aa09494996127efe&userUid=673839277975281664&orgUid=673839277979475969";

            SyndicationFeed workFeed = null;
            using (var reader = XmlReader.Create(url))
            {
                workFeed = SyndicationFeed.Load(reader);
            }

            if (workFeed == null)
            {
                return;
            }

            workFeed.Items.ToList().ForEach(item => Console.WriteLine(item.Title.Text));

            Console.ReadKey();
        }
    }
}
