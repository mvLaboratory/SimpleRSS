using GuiEnvironment;
using System;
using System.Windows;

namespace eleksRssGUI
{
    public class ShellViewModule : BaseViewModel, IShellViewModel
    {
        public Int32 WindowHeight
        {
            get
            {
                return _windowHeight;
            }
            set
            {
                setWindowHeight(value);
            }
        }

        public ShellViewModule()
        {
        }

        private void setWindowHeight(Int32 height)
        {
            _windowHeight = height;
        }

        private Int32 _windowHeight = 500;
    }
}
