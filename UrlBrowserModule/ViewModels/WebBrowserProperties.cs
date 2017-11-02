using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace UrlBrowserModule
{
    public static class WebBrowserProperties
    {
        public static readonly DependencyProperty UrlProperty = DependencyProperty.RegisterAttached("Url", typeof(string), typeof(WebBrowserProperties), new UIPropertyMetadata(string.Empty, UrlPropertyChanged));

        public static string GetUrl(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(UrlProperty);
        }

        public static void SetUrl(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(UrlProperty, value);
        }

        public static void UrlPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            WebBrowser webBrowser = dependencyObject as WebBrowser;           
            if (webBrowser != null)
            {
                String browserUrl = GetUrl(webBrowser);
                if (browserUrl != null && browserUrl != string.Empty)
                {
                    webBrowser.Navigate(browserUrl);    
                }
                else
                {
                    webBrowser.NavigateToString("<Html></Html>");
                }
                webBrowser.LoadCompleted += WebBrowserLoaded;
            }
        }

        public static void WebBrowserLoaded(object sender, NavigationEventArgs e)
        {
        }
    }
}
