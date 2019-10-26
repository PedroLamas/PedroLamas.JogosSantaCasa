using System;
using System.Linq;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using PedroLamas.JogosSantaCasa.Model;

namespace PedroLamas.JogosSantaCasa.ViewModel
{
    public class RefreshViewModel : ViewModelBase
    {
        private readonly IMainModel _mainModel;
        private readonly IJogosSantaCasaService _jogosSantaCasaService;
        private readonly INavigationService _navigationService;
        private readonly ISystemTrayService _systemTrayService;
        private readonly IShellTileService _shellTileService;

        private string _statusText;

        #region Properties

        public RelayCommand RefreshCommand { get; private set; }

        public string StatusText
        {
            get
            {
                return _statusText;
            }
            set
            {
                if (_statusText == value)
                    return;

                _statusText = value;

                RaisePropertyChanged(() => StatusText);
            }
        }

        public bool IsBusy
        {
            get
            {
                return _systemTrayService.IsBusy;
            }
            set
            {
                if (_systemTrayService.IsBusy == value)
                    return;

                if (value)
                {
                    _systemTrayService.SetProgressIndicator(string.Empty);
                }
                else
                {
                    _systemTrayService.HideProgressIndicator();
                }

                RaisePropertyChanged(() => IsBusy);

                RefreshCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        public RefreshViewModel(IMainModel mainModel, IJogosSantaCasaService jogosSantaCasaService, INavigationService navigationService, ISystemTrayService systemTrayService, IShellTileService shellTileService)
        {
            _mainModel = mainModel;
            _jogosSantaCasaService = jogosSantaCasaService;
            _navigationService = navigationService;
            _systemTrayService = systemTrayService;
            _shellTileService = shellTileService;

            RefreshCommand = new RelayCommand(() =>
            {
                IsBusy = true;

                StatusText = "A actualizar os resultados...";

                _jogosSantaCasaService.GetResults(result =>
                {
                    if (result.Error != null)
                    {
                        StatusText = "Ocorreu um erro ao actualizar os resultados!";

                        IsBusy = false;

                        return;
                    }
                    else if (result.StatusCode != System.Net.HttpStatusCode.NotModified)
                    {
                        _mainModel.Results = result.Data;
                        _mainModel.ETag = result.ETag;
                    }

                    _systemTrayService.HideProgressIndicator();

                    if (_navigationService.CanGoBack)
                    {
                        _navigationService.RemoveBackEntry();
                    }
                    _navigationService.NavigateTo(new Uri("/View/ResultsPage.xaml", UriKind.Relative));
                }, _mainModel.ETag, null);
            }, () => !IsBusy);

#if !WP8
            DispatcherHelper.RunAsync(UpdateTiles);
#endif
        }

#if !WP8
        private void UpdateTiles()
        {
            if (!_shellTileService.LiveTilesSupported)
            {
                return;
            }

            var primaryTile = _shellTileService.ActiveTiles.FirstOrDefault();

            if (primaryTile != null)
            {
                primaryTile.Update(new ShellTileServiceFlipTileData()
                {
                    SmallBackgroundImage = new Uri("/Totojogos_159x159.png", UriKind.Relative),
                    BackgroundImage = new Uri("/Totojogos_336x336.png", UriKind.Relative),
                    WideBackgroundImage = new Uri("/Totojogos_691x336.png", UriKind.Relative)
                });
            }
        }
#endif
    }
}