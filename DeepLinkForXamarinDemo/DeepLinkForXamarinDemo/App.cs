using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Application.Current.Properties["page1"] = new Page1();
            Application.Current.Properties["page2"] = new Page2();
            Application.Current.Properties["mainpage"] = new RealMainPage();

            Debug.WriteLine("hello APP()");
            try
            {
                string startURL = (string)Application.Current.Properties["startURL"];
                switch (startURL)
                {
                    case "page1":
                        MainPage = new NavigationPage((Page1)Application.Current.Properties[startURL]);
                        break;
                    case "page2":
                        MainPage = new NavigationPage((Page2)Application.Current.Properties[startURL]);
                        break;
                    case "mainpage":
                        MainPage = new NavigationPage((RealMainPage)Application.Current.Properties[startURL]);
                        break;
                }

            }
            catch (Exception e)
            {
                MainPage = new NavigationPage((RealMainPage)new RealMainPage());
            }
            
           
            //MainPage = new NavigationPage(new RealMainPage());

        }

        protected override void OnStart()
        {
            Debug.WriteLine("hello onStart");
            //string startURL = (string)Application.Current.Properties["startURL"];
            //if (startURL == null)
            //{
            //    return;
            //}
            //switch (startURL)
            //{
            //    case "page1":
            //        MainPage = (Page1)Application.Current.Properties[startURL];
            //        break;
            //    case "page2":
            //        MainPage = (Page2)Application.Current.Properties[startURL];
            //        break;
            //    case "mainpage":
            //        MainPage = (RealMainPage)Application.Current.Properties[startURL];
            //        break;
            //}
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Debug.WriteLine("hello onSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("hello OnResume");
            //string startURL = (string)Application.Current.Properties["startURL"];
            //if (startURL == null)
            //{
            //    return;
            //}
            //switch (startURL)
            //{
            //    case "page1":
            //        MainPage = (Page1)Application.Current.Properties[startURL];
            //        break;
            //    case "page2":
            //        MainPage = (Page2)Application.Current.Properties[startURL];
            //        break;
            //    case "mainpage":
            //        MainPage = (RealMainPage)Application.Current.Properties[startURL];
            //        break;
            //}
        }
    }
}
