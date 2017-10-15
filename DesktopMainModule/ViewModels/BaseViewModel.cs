﻿using EleksRssCore;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DesktopMainModule
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public delegate void TestDelegate(IModel model);

        public ObservableCollection<IModel> ObservableCategories { get; set; }
        public ObservableCollection<IModel> ObservableRssItems { get; set; }
        public abstract TestDelegate GetDelegate();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}