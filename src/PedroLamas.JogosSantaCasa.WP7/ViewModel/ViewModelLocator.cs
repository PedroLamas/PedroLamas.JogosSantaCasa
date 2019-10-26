using System;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using PedroLamas.JogosSantaCasa.Model;

namespace PedroLamas.JogosSantaCasa.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            Register<INavigationService, NavigationService>();
            Register<IMessageBoxService, MessageBoxService>();
            Register<ISystemTrayService, SystemTrayService>();
            Register<IVibrationService, VibrationService>();
            Register<IShareLinkService, ShareLinkService>();
            Register<IMarketplaceReviewService, MarketplaceReviewService>();
            Register<IMarketplaceSearchService, MarketplaceSearchService>();
            Register<IWebBrowserService, WebBrowserService>();
            Register<IClipboardService, ClipboardService>();
            Register<IEmailComposeService, EmailComposeService>();
            Register<ISmsComposeService, SmsComposeService>();
            Register<IShareStatusService, ShareStatusService>();
            Register<IShellTileService, ShellTileWithAddService>();

            Register<IMainModel, MainModel>();
            Register<IJogosSantaCasaService, JogosSantaCasaService>();

            Register<RefreshViewModel>();
            Register<ResultsViewModel>();
            Register<BettingViewModel>();
            Register<AboutViewModel>();
        }

        public RefreshViewModel Refresh
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RefreshViewModel>();
            }
        }

        public ResultsViewModel Results
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ResultsViewModel>();
            }
        }

        public BettingViewModel Betting
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BettingViewModel>();
            }
        }

        public AboutViewModel About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        #region Auxiliary Methods

        private void Register<TInterface, TClass>()
            where TInterface : class
            where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TInterface>())
            {
                SimpleIoc.Default.Register<TInterface, TClass>();
            }
        }

        private void Register<TClass>() where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TClass>())
            {
                SimpleIoc.Default.Register<TClass>();
            }
        }

        private void Register<TClass>(Func<TClass> factory) where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TClass>())
            {
                SimpleIoc.Default.Register(factory);
            }
        }

        #endregion
    }
}