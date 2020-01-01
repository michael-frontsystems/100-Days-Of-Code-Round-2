using System;
using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismDemoR2.Views;

namespace PrismDemoR2.ViewModels
{
    public class Test1PageViewModel : BindableBase, INavigationAware, IDestructible, IActiveAware
    {
        public DelegateCommand HomeCommand { get; set; }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaisePropertyChanged); }
        }

        private INavigationService _navigationService;

        public event EventHandler IsActiveChanged;

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
            Console.WriteLine($"{nameof(Test1PageViewModel)} - OnNavigatedFrom");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine($"{nameof(Test1PageViewModel)} - OnNavigatedTo");
        }

        public void Destroy()
        {
            Console.WriteLine($"{nameof(Test1PageViewModel)} - Destroy!");
        }

        private void RaisePropertyChanged()
        {
            Console.WriteLine($"{nameof(Test1PageViewModel)} TAB IsActive: " + _isActive);
        }
    }
}
