using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DeepLinkForXamarinDemo
{
    public partial class RealMainPage : ContentPage
    {
        Page firstPage = new Page();
        public RealMainPage()
        {
            Debug.WriteLine("Init RealMainPage");
            InitializeComponent();
            
            string startURL = null;
            try
            {
                startURL = (string)Application.Current.Properties["startURL"];
                switch (startURL)
                {
                    case "page1":
                        //firstPage = (Page1)Application.Current.Properties[startURL];
                        firstPage = new Page1();
                        break;
                    case "page2":
                        //firstPage = (Page2)Application.Current.Properties[startURL];
                        firstPage = new Page2();
                        break;
                    case "mainpage":
                        //firstPage = (RealMainPage)Application.Current.Properties[startURL];
                        firstPage = new RealMainPage();
                        break;
                }
            }
            catch (Exception e)
            {
                
            }
            Navigation.PushAsync(firstPage);
        }

        async void onPageBtClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(firstPage);
        }


    }
}
