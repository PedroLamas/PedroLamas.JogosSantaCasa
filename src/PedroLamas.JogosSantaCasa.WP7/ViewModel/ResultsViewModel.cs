using System;
using System.Collections.Generic;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Shell;
using PedroLamas.JogosSantaCasa.Model;

namespace PedroLamas.JogosSantaCasa.ViewModel
{
    public class ResultsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMainModel _mainModel;
        private readonly IEmailComposeService _emailComposeService;
        private readonly ISmsComposeService _smsComposeService;
        private readonly IShareStatusService _shareStatusService;

        private bool _isBettingEnabled;
        private bool _applicationBarMenuVisible;

        #region Properties

        public IList<SantaCasaGamesResponse> Results
        {
            get
            {
                return _mainModel.Results;
            }
        }

        public int SelectedResultIndex
        {
            get
            {
                return _mainModel.SelectedResultIndex;
            }
            set
            {
                if (_mainModel.SelectedResultIndex == value)
                    return;

                _mainModel.SelectedResultIndex = value;

                RaisePropertyChanged(() => SelectedResultIndex);
            }
        }

        public RelayCommand SendEmailCommand { get; private set; }

        public RelayCommand SendMessageCommand { get; private set; }

        public RelayCommand ShareCommand { get; private set; }

        public RelayCommand RefreshCommand { get; private set; }

        public RelayCommand ShowAboutCommand { get; private set; }

        public RelayCommand PageLoadedCommand { get; private set; }

        public bool IsBettingEnabled
        {
            get
            {
                return _isBettingEnabled;
            }
            set
            {
                if (_isBettingEnabled == value)
                    return;

                _isBettingEnabled = value;

                RaisePropertyChanged(() => IsBettingEnabled);
                RaisePropertyChanged(() => ApplicationBarMode);
                RaisePropertyChanged(() => ApplicationBarOpacity);
            }
        }

        public RelayCommand<ApplicationBarStateChangedEventArgs> ApplicationBarStateChangedCommand { get; private set; }

        public bool ApplicationBarMenuVisible
        {
            get
            {
                return _applicationBarMenuVisible;
            }
            set
            {
                if (_applicationBarMenuVisible == value)
                    return;

                _applicationBarMenuVisible = value;

                RaisePropertyChanged(() => ApplicationBarMenuVisible);
                RaisePropertyChanged(() => ApplicationBarOpacity);
            }
        }

        public double ApplicationBarOpacity
        {
            get
            {
                return _applicationBarMenuVisible ? 0.999 : (_isBettingEnabled ? 0.5 : 0);
            }
        }

        public ApplicationBarMode ApplicationBarMode
        {
            get
            {
                return IsBettingEnabled ? ApplicationBarMode.Default : ApplicationBarMode.Minimized;
            }
        }

        #endregion

        public ResultsViewModel(IMainModel mainModel, INavigationService navigationService, IEmailComposeService emailComposeService, ISmsComposeService smsComposeService, IShareStatusService shareStatusService)
        {
            _mainModel = mainModel;
            _navigationService = navigationService;
            _emailComposeService = emailComposeService;
            _smsComposeService = smsComposeService;
            _shareStatusService = shareStatusService;

            SendEmailCommand = new RelayCommand(() =>
            {
                var selectedResult = Results[SelectedResultIndex];
                var subject = selectedResult.ToString();
                var body = selectedResult.Result.ToString();

                _emailComposeService.Show(subject, body);
            }, () => SelectedResultIndex != -1);

            SendMessageCommand = new RelayCommand(() =>
            {
                var selectedResult = Results[SelectedResultIndex];
                var subject = selectedResult.ToString();
                var body = selectedResult.Result.ToString();

                _smsComposeService.Show(string.Empty, subject + " - " + body);
            }, () => SelectedResultIndex != -1);

            ShareCommand = new RelayCommand(() =>
            {
                var selectedResult = Results[SelectedResultIndex];
                var subject = selectedResult.ToString();
                var body = selectedResult.Result.ToString();

                _shareStatusService.Show(subject + " - " + body);
            }, () => SelectedResultIndex != -1);

            RefreshCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(new Uri("/View/RefreshPage.xaml", UriKind.Relative));
            });

            ShowAboutCommand = new RelayCommand(() =>
            {
                _navigationService.NavigateTo(new Uri("/View/AboutPage.xaml", UriKind.Relative));
            });

            ApplicationBarStateChangedCommand = new RelayCommand<ApplicationBarStateChangedEventArgs>(e =>
            {
                ApplicationBarMenuVisible = e.IsMenuVisible;
            });

            PageLoadedCommand = new RelayCommand(() =>
            {
                _navigationService.RemoveBackEntry();
            });
        }
    }
}