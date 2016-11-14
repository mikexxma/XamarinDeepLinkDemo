using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DeepLinkForXamarinDemo
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new RealMainPage());
            Application.Current.Properties["page1"] = new Page1();
            Application.Current.Properties["page2"] = new Page2();
            Application.Current.Properties["mainpage"] = new RealMainPage();
        }

        protected override void OnStart()
        {
           
            string startURL = (string)Application.Current.Properties["startURL"];
            if (startURL == null)
            {
                return;
            }
            switch (startURL)
            {
                case "page1":
                    MainPage = (Page1)Application.Current.Properties[startURL];
                    break;
                case "page2":
                    MainPage = (Page2)Application.Current.Properties[startURL];
                    break;
                case "mainpage":
                    MainPage = (RealMainPage)Application.Current.Properties[startURL];
                    break;
            }
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            string startURL = (string)Application.Current.Properties["startURL"];
            if (startURL == null)
            {
                return;
            }
            switch (startURL)
            {
                case "page1":
                    MainPage = (Page1)Application.Current.Properties[startURL];
                    break;
                case "page2":
                    MainPage = (Page2)Application.Current.Properties[startURL];
                    break;
                case "mainpage":
                    MainPage = (RealMainPage)Application.Current.Properties[startURL];
                    break;
            }
        }
    }
}
