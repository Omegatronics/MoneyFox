﻿using EntityFramework.DbContextScope;
using Microsoft.EntityFrameworkCore;
using MoneyFox.Business.Authentication;
using MoneyFox.Business.ViewModels;
using MoneyFox.DataAccess;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace MoneyFox.Business
{
    /// <summary>
    ///     Entry piont to the Application for MvvmCross.
    /// </summary>
    public class App : MvxApplication
    {
        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        public override async void Initialize()
        {
            var dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();

            using (dbContextScopeFactory.Create())
            {
                await ambientDbContextLocator.Get<ApplicationContext>().Database.MigrateAsync();
            }

            RegisterAppStart(new AppStart());
        }
    }

    public class AppStart : IMvxAppStart
    {
        public async void Start(object hint = null)
        {
            var navigationService = Mvx.Resolve<IMvxNavigationService>();

            if (Mvx.Resolve<Session>().ValidateSession())
            {
                await navigationService.Navigate<MenuViewModel>();
                await navigationService.Navigate<AccountListViewModel>();
            }
            else
            {
                await navigationService.Navigate<LoginViewModel>();
            }
        }
    }
}