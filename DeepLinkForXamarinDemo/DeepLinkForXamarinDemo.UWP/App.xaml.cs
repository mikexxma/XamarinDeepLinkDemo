﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DeepLinkForXamarinDemo.UWP
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Debug.WriteLine("On UWP App()");
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            this.LeavingBackground += OnLeavingBackground;
            this.EnteredBackground += OnEnteredBackground;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Debug.WriteLine("OnLaunched");
            Frame rootFrame = Window.Current.Content as Frame;
            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                Xamarin.Forms.Forms.Init(e);

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Ensure the current window is active
            Window.Current.Activate();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            Debug.WriteLine("OnSuspending");
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }


        protected override void OnActivated(IActivatedEventArgs e)
        {
           
            Debug.WriteLine("hello OnActivated");
            //Type deepLinkPageType = typeof(RealMainPage);
            if (e.Kind == ActivationKind.Protocol)
            {
                var protocolArgs = (ProtocolActivatedEventArgs)e;
                string absolutePath = protocolArgs.Uri.AbsolutePath;
                switch (absolutePath)
                {
                    case "/":
                        Xamarin.Forms.Application.Current.Properties["startURL"] = "mainpage";
                        //deepLinkPageType = typeof(RealMainPage);
                        break;
                    case "/index.html":
                        Xamarin.Forms.Application.Current.Properties["startURL"] = "mainpage";
                        //deepLinkPageType = typeof(RealMainPage);
                        break;
                    case "/page1.html":
                        Xamarin.Forms.Application.Current.Properties["startURL"] = "page1";
                        //deepLinkPageType = typeof(Page1);
                        break;
                    case "/page2.html":
                        Xamarin.Forms.Application.Current.Properties["startURL"] = "page2";
                       // deepLinkPageType = typeof(Page2);
                        break;
                }
            }
            //if (rootFrame.Content == null)
            //{
            //    // Default navigation
            //    rootFrame.Navigate(deepLinkPageType, e);
            //}

            InitFristPageClass.initFirstPage();
            // Ensure the current window is active
           
            new RealMainPage();
            //Window.Current.Activate();

        }

        public  void OnLeavingBackground(System.Object sender, LeavingBackgroundEventArgs e)
        {
            Debug.WriteLine("GoodBye Background");
        }


        public void OnEnteredBackground(System.Object sender, EnteredBackgroundEventArgs e)
        {
            Debug.WriteLine("Hello Background");
        }

    }
}
