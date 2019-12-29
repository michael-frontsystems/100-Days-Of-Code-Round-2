﻿using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismDemoR2.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware, IDestructible
    {
        private string userName;
        public string UserName
        {
            get => userName ?? string.Empty;
            set => SetProperty(ref userName, value);
        }

        private string password;
        public string Password
        {
            get { return password ?? string.Empty; }
            set
            {
                SetProperty(ref password, value);
                if (string.IsNullOrEmpty(password))
                    HasPassword = true;
                else
                    HasPassword = false;
            }
        }

        private bool hasPassword;
        public bool HasPassword
        {
            get => hasPassword;
            set => SetProperty(ref hasPassword, value);
        }

        public DelegateCommand LoginCommand { get; set; } 

        private INavigationService _navigationService; 

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new DelegateCommand(CallLogInCommand);

#if DEBUG
            UserName = "michael@email.no";
            Password = "3+3er6";
#endif
        }

        private void CallLogInCommand()
        {
            if (userName.Length > 0 && password.Length > 0)
            {
                //_navigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage"));
                _navigationService.NavigateAsync("CustomTabbedPage");
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            Console.WriteLine("Navigated FROM!");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine("Navigated TO!");
        }

        public void Destroy()
        {
            Console.WriteLine("On Destroy!");
        }
    }
}
