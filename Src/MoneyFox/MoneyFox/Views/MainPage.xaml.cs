﻿using System;
using MoneyFox.Business.ViewModels;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoneyFox.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MvxTabbedPage<MainViewModel>
	{
		public MainPage ()
		{
			InitializeComponent ();
		}
	}
}