﻿using NetDocTest.Pages;

namespace NetDocTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StackLayoutTest());
        }
    }
}