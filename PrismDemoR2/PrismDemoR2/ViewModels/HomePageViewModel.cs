using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismDemoR2.ViewModels
{
    public class HomePageViewModel : BindableBase, INavigationAware, IDestructible
    {
    
        private INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            //
        }

        public void Destroy()
        {
            //
        }
    }
}
