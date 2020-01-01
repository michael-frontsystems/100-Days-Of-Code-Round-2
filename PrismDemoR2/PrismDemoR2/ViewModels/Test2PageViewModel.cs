using System;
using Prism;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismDemoR2.ViewModels
{
    public class Test2PageViewModel : BindableBase, INavigationAware, IDestructible, IActiveAware
    {
        public event EventHandler IsActiveChanged;

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaisePropertyChanged); }
        }

        public Test2PageViewModel()
        {
        }

        private void RaisePropertyChanged()
        {
            Console.WriteLine($"{nameof(Test1PageViewModel)} TAB IsActive: " + _isActive);
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
