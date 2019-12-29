using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemoR2.Views;

namespace PrismDemoR2.ViewModels
{
    public class Test1PageViewModel : BindableBase, INavigationAware, IDestructible
    {
        public DelegateCommand HomeCommand { get; set; }

        private INavigationService _navigationService;

        public Test1PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            HomeCommand = new DelegateCommand(GoToHomeCommand);
        }

        private async void GoToHomeCommand()
        {
            Console.WriteLine(_navigationService.GetNavigationUriPath());


            var navigationParameters = new NavigationParameters();
            navigationParameters.Add("KEY", "VALUE");

            await _navigationService.NavigateAsync("HomePage", navigationParameters);
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
