using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksRssCore
{
    public interface IDataSaver
    {
        void saveCategory(Category item);
    }
}
