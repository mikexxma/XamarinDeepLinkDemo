using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DeepLinkForXamarinDemo
{

    public static class InitFristPageClass
    {
        public static Page firstPage;
        public static void initFirstPage()
        {
           
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
        }
    }

    public partial class RealMainPage : ContentPage
    {
        public RealMainPage()
        {
            Debug.WriteLine("Init RealMainPage");
            InitializeComponent();
            if (InitFristPageClass.firstPage != null)
            {
                Navigation.PushAsync(InitFristPageClass.firstPage);
            }
            
        }

       

        async void onPageBtClick(object sender, EventArgs e)
        {
            if (InitFristPageClass.firstPage != null)
            {
                await MyFrame.Navigation.PushAsync(InitFristPageClass.firstPage);
            }
            
        }


    }
}
