﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace appLifecycleTutorial
{
	public partial class App : Application
	{
      const string displayText = "displayText";

      public string DisplayText { get; set; }

      public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

      protected override void OnStart()
      {
         Console.WriteLine("OnStart");

         if (Properties.ContainsKey(displayText))
         {
            DisplayText = (string)Properties[displayText];
         }
      }

      protected override void OnSleep()
      {
         Console.WriteLine("OnSleep");
         Properties[displayText] = DisplayText;
      }

      protected override void OnResume()
      {
         Console.WriteLine("OnResume");
      }
   }
}
