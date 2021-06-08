﻿using RecoverAccount.Services;
using RecoverAccount.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecoverAccount
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new RecoverAccountPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
