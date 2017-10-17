using EleksRssCore;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesktopMainModule
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
