using Microsoft.Phone.Controls;

namespace PedroLamas.JogosSantaCasa.View
{
    public partial class RefreshPage : PhoneApplicationPage
    {
        public RefreshPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!NavigationService.CanGoBack)
            {
                TransitionService.SetNavigationInTransition(this, null);
            }            
        }
    }
}