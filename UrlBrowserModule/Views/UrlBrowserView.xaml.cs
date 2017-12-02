using System.Reflection;
using System.Windows.Controls;

namespace UrlBrowserModule
{
    public partial class UrlBrowserView : UserControl
    {
        public UrlBrowserView(IUrlBrowserViewModule model)
        {
            InitializeComponent();
            DataContext = model;
        }

        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fiComWebBrowser == null) return;
            object objComWebBrowser = fiComWebBrowser.GetValue(wb);
            if (objComWebBrowser == null) return;
            objComWebBrowser.GetType().InvokeMember( "Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });
        }

        private void NewsBrowser_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            HideScriptErrors(NewsBrowser, true);
        }
    }
}
