using EleksRssCore;
using System.Collections.Generic;
using Prism.Events;

namespace GuiEnvironment
{
    public class CategoriesListChangedEvent : PubSubEvent<Category>
    {
    }
}
