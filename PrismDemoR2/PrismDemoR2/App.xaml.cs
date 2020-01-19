using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Prism.Ioc;
using Prism;
using PrismDemoR2.ViewModels;
using PrismDemoR2.Views;
using PrismDemoR2.Services;
using PrismDemoR2.Services.Interface;

namespace PrismDemoR2
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null): base(initializer)
        {
            //
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            
            NavigationService.NavigateAsync("LoginPage");
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CustomTabbedPage>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<Test1Page, Test1PageViewModel>();
            containerRegistry.RegisterForNavigation<Test2Page, Test2PageViewModel>();

            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
            containerRegistry.RegisterSingleton<IHttpService, HttpService>();
        }
    }
}
