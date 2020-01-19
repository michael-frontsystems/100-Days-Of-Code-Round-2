# #100DaysOfCode (Round 2)

## Daily logs for R2

This is my second round of #100DaysOfCode. My focus for this round is to learn more about Xamarin, C# and Prism which my current bread and butter. The plan is to learn the basics of MVVM and prism and the end result of this challenge will be a xamarin version of my old native ios app. 


## Learning Goals
1. _Prism_
2. _MVVM_
3. Rider IDE (VS 2019 is really slow)
4. _Design Pattern used in CS (Factory Pattern)_
5. _SQLite_
6. _Sync mechanism_ 

## Day 1: December 23, 2019 Monday

**Today's Progress**: 

*Setup Project
- Create new xamarin project 
- Add nuget package Prism.Unity.Forms
- Add the Prism reference in your App.xaml.cs file
- On App class inherit from PrismApplication, add the Prism initializer parameter in the constructor and override the OnInitialized and RegisterTypes methods on App.xaml.cs 
- Add Platform initializers on iOS AppDelegate.cs

*Create new views
- Add empty class for ViewModel (e.g HomePageViewModel)
- Add emply xaml with cs for Views (e.g HomePage)
- Add it as initial page in App.xaml.cs OnInitialized() using NavigationService.NavigateAsync();
- Update login xaml and design a simple login with logo, text boxes and a button

**Thoughts:** I aquianted myself on how to setup a new iOS project that use Prism Library and call simple navigation. I started to recall how to design  a view on XML.   


## Day 2: December 24, 2019 Tuesday

**Today's Progress**: 

*Started a MVVM mentality
- Made LoginViewModel as BindableBase, INavigationAware, IDestructible
- Implement methods for navigation aware (e.g NavigatedTo, NavigatedFrom)
- Implement methods for IDestructible (e.g Destroy)
- Add binding to username and password entry field to a variable in ViewModel 
- Add binding command to login button to call a command (method) to trigger the login.

**Thoughts:** I started to change my mentality from an MVC thinking to a MVVM way. I get to understand now how binding works for textfields and button command but I need to read more about bindablebase and dependecy indjection 

**Assignment** 
Read about the folowing:
-**BindableBase**
- Dependecy Injection
    - https://www.theserverside.com/news/1321158/A-beginners-guide-to-Dependency-Injection


## Day 3: December 25, 2019 Wednesday

**Today's Progress**: 

**Study Notes** 
- **INotifyPropertyChanged** - _its an interface to notify clients, typical binding clients that a property value has changed. This interface rasies PropertyChangedEventHandler event_ 
- **BindableBase** - _Is an abstract class that implements INotifyPropertyChanged interface and provide SetProperty<T>, .You can reduce the set method to just one line also ref parameter allows you to update its value_
    Example:
    ```C#
       private string _firstName;
       public string FirstName
       {
           get { return _firstName; }
           set { SetProperty(ref _firstName, value); }
       }

    `````
    
    
### Day 4: December 26, 2019 Thursday

    **Today's Progress**: 

    *Set up Prism TabbedPage (https://xamgirl.com/prism-in-xamarin-forms-step-by-step-part-4/) 
    - Created a tabbedpage class as Parent of the 2 or more content pages. (e.g CustomTabbedPage.cs) 
    - Then I added two new ViewPages to be children of the CustomTabbedPage. (e.g Test1Page, Test2Page)
    - Register the following views in App.cs
    - Add header ui for both children as a temporary Navigation bar
    - Add temporary icons to each tab (e.g Idea and Settings)

**Thoughts:** I started using tabbed page in PRISM as an investigation on how to use it and also to get an initial idea on how can I apply this approach to UserVIewPage in CS. Its all visual changes in today's progress but I will investigate more if NavigationAware methods will still work on a tabbed page setup.

**Assignment** 
Investigate about the folowing:
- If NavigationAware methods still work on Tabbed Page Setup
- If IDestructible methods still work on Tabbed Page Setup
- Parameter passing when navigating


## Day 5: December 28, 2019 Saturday

**Today's Progress**: 

**Big Mistake Here!**: 
- Fix Navigation for login and for calling a child view
```C#
    //Navigation as PUSH 
    await _navigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage/HomePage"));
    
    //Navigation as MODAL 
    await _navigationService.NavigateAsync("HomePage");
```
```XAML CustomTabbedPage.xaml
  <?xml version="1.0" encoding="UTF-8"?>
  <TabbedPage xmlns="http://xamarin.com/schemas/2014/forms"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:local="clr-namespace:PrismDemoR2.Views"
               x:Class="PrismDemoR2.Views.CustomTabbedPage">
      <TabbedPage.Children>
        <local:Test1Page IconImageSource="idea.png"/>
        <local:Test2Page IconImageSource="settings.png"/>
      </TabbedPage.Children>
  </TabbedPage>
```
**Correction**:
- Proper navigation for Prism:
```C# LoginViewModel.cs
    /*
        Initially I am suing this method thinking that the children in CustomTabbedPage are enclosed to a NavigationPage
        but the real scenario here is that I am enclosing the CustomTabbedPage within NavigationPage
        thats why when I push a child to the navigation it pushes it the the whole TabbedPage.
    */
        _navigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage"));
```
```C# LoginViewModel.cs
    /*
        The fix for this is to call CustomTabbedPage as MODAL then enclose all the children with NavigationPage in XAML
    */
      _navigationService.NavigateAsync("CustomTabbedPage");
```
```XAML CustomTabbedPage.xaml
  <?xml version="1.0" encoding="UTF-8"?>
  <TabbedPage xmlns="http://xamarin.com/schemas/2014/forms"
               xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
               xmlns:local="clr-namespace:PrismDemoR2.Views"
               x:Class="PrismDemoR2.Views.CustomTabbedPage">
      <TabbedPage.Children>
           <NavigationPage Title="HOME" Icon="idea.png">
              <x:Arguments>
                  <local:Test1Page />
              </x:Arguments>
          </NavigationPage>
          <NavigationPage Title="SETTINGS" Icon="settings.png">
              <x:Arguments>
                  <local:Test2Page />
              </x:Arguments>
          </NavigationPage>
          <!--<local:Test2Page IconImageSource="settings.png"/>-->
      </TabbedPage.Children>
  </TabbedPage>
```

**Thoughts:** Fix all navigation since all my previous calling of new page are animated from bottom to top which is like calling a  Modal View (in native). It is a little confusing because I was still on "native way" of thinking and Xamarin + Prism has its own way of calling views and it seems simple but needs more attention to how we use NavigateAsync. 

**Assignment** 
Investigate about the folowing:
- If NavigationAware methods still work on Tabbed Page Setup
- If IDestructible methods still work on Tabbed Page Setup
- Parameter passing when navigating


## Day 6: December 31, 2019 Tuesday

**Today's Progress**: (From Assignment) 
- NavigationAware methods still works on Tabbed Page Setup 
- IDestructible method Destroy() is not triggered if Views are children of the Tabbed page  

**Thoughts:** The children of a tabbed page behaves similar to the native one, they are somewhat static and will still trigger INavigationAware if they have their own children to push and pop. but a new IActivateAware interface was added to get to know if the Tab is activated or not. For example, If Tab1Page was selected _IsActive_ flag will return true and if other tabs were selected then _IsActive_ flag will return false.  


## Day 7: January 3, 2020 Friday

**Today's Progress**:
- NavigationPage -
    - We register the navigation page in RegisterTypes()
    - Add the “NavigationPage” to the uri when navigating (e.g navigationService.NavigateAsync(_uri_);
- Customize NavigationPage (e.g change navigation bar color)
        - Create a new class and inherit from NavigationPage

```C# CustomNavigationPage.cs

using System;
using Xamarin.Forms;

namespace Sample.Views
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage()
        {
        }
    }
}
```
- Deep Linking - which allows creating your own navigation stack of pages. this will create a stack from view 1 to view 5 and it can navigate back to view 1 with a back button. (e.g LoginPage, HomePage, HomeDetailPage, HomeDetailOptionsPage)
- CanNavigate -  is a method provided by Prism, in which one you set if you can navigate or not.  To use it is simple, you just have to implement the interface called IConfirmNavigation and use the method CanNavigate. If the method is set to false, you won’t be able to navigate to any page even if you do _navigationService.NavigateAsync(….).

```
public class LoginViewModel : IConfirmNavigation
{
    public public bool CanNavigate(NavigationParameters parameters)
    {
        return true;
    }
}
```
- Platform Services - When creating a platform specific service or feature we define the dependency on and register them in each platform RegisterType() block.
- Delegate Commands with observable CanExecute state,  this means the property/method associated to it will always be observed updating CanExecute state automatically.

```
    
    public ICommand GetBatteryStatusCommand { get; set; }
    public bool IsValid { get; set; }
    
    ...
        IsValid = false;
    ...
    
    GetBatteryStatusCommand = new Command(GetBatteryStatus, ()=> IsValid)
    
    async void GetBatteryStatus()
    {
        //
    }
```
**Thoughts:** Its good to get back to business after few days of slacking. More on reading this time but it gives an impact on knowing Prism deeper.    

**Assignment** 
- Try ICommand CanExecute if it really restricts the execution of the command
- Try IConfirmNavigation false if it is the equivalent of IsVisible flags I've been using. 
- Try CustomNavigationPage to customise navigation bar colors

## Day 8: January 5, 2020 Sunday

**Today's Progress**:
- Tried _ICommand CanExecute_
    - Thoughts: The one stated in tutorial did not meet reality, I did set CanExecute to true but the command did still execute.
    - Working Around:
         ```
            public bool DoNotAllowLogin { get; set; } = false;
            ...
            

            LoginTappedCommand = new DelegateCommand(DoLoginTappedCommand, CanLogin);
            ...
            
            private bool CanLogin()
            {
                return DoNotAllowLogin;
            }
            ...
            
            private async void DoLoginTappedCommand()
            {
                if(!LoginTappedCommand.CanExecute())
                {
                    return;
                }
            }
        ```
- Tried _IConfirmNavigation_
    - Thoughts: When implementing IConfirmNavigation Interface and set it to false, the view will restrice any navigation. So this could replace my implementation of IsVisible flag and set CanNavigate to return false after calling navigationAsync. 
    

## Day 9: January 6, 2020 Monday

**Today's Progress**:
- Tried _IConfirmNavigation_
    - Thoughts: When implementing IConfirmNavigation Interface and set it to false, the view will restrice any navigation. So this could replace my implementation of IsVisible flag and set CanNavigate to return false after calling navigationAsync. 


## Day 10: January 7, 2020 Tuesday

**Today's Progress**:
- Created an interface  IAuthenticationService _(for all platform)_
- Add LoginWithEmailAndPassword() method
- Created a class AuthenticationSergice _(for all platform)_
- Implement LoginWithEmailAndPassword() currently with just a console log
- Register the service inside RegisterTypes() as RegisterSingleton<>
    ``` 
    containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
    ```
- Inject IAuthenticationService to LoginViewModel
    ```
    public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
    ```
- Create a local reference of authenticationService
    ```
    private readonly IAuthenticationService _authenticationService;    
    ```
- Call LoginWithEmailAndPassword() from _authenticationService 
```
    _authenticationService.LoginWithEmailAndPassword(); 
```

**Assignment** 
- How CS call Login API 
- How is AuthenticationService is created  
- Read about HttpService


## Day 11: January 10, 2020 Friday

**Today's Progress**:
- Testing Rider IDE and compare building times to Visual Studio 2019
    - Rider = (12-13 seconds)
    - Visual Studio (20 seconds)

**Thoughts:** I miss the last two days because I am waiting for my norskprøve results and thank God, I got the result got an A2 level. Today, I'm trying a new development environment (IDE) becuase I am annoyed how slow visual studio is when building and running an iOS app on a device. 

**Assignment** 
- Factory Design Pattern
- How CS call Login API 
- How is AuthenticationService is created  
- Read about HttpService

## Day 12: January 11, 2020 Saturday

**Today's Progress**:
- Factory Design Pattern - Is part of the design pattern where we have a Factory Class that create an object with out exposing the creation logic to the client. 
    - Example is the `ShapeFactory class`,  that has a method `Create(string shapeType)` and inside that method we initialize 
      what type of Shape class is initialized.
      
     ``` C#
    class Shape
    {
        private Shape(string name)
        {
            Console.Writeline(name);
        }
    }
    
    class ShapeFactory
    {
        private Shape Create(string shapeType)
        {
            if (shapeType == 'Circle')
            {
                var circle = new Shape(Circle');
                return circle;
            }
            
            if (shapeType == 'Triangle')
            {
                var triangle = new Shape(Triangle');
                return triangle;
            }
            
           ...
        }
    }
    ``` 

- CS use Factory Pattern in Authentication. 
    - `AuthenticationFactory class` has `Create()` to create the `AuthenticationServiceReal.cs` or `AuthenticationServiceMock.cs`
    - `LoginViewModel class`
        - we inject the authenticationServiceFactory 
        - when calling Authenticate method we call the `var authenticationService = authenticationServiceFactory.Create(model);`
        - then we call `authenticationService.Login()` API
        
**Thoughts:** 
I get to know how factory pattern is used in CS project. I'll try to follow the same pattern when I start with my FZ xamarin versions.

**Assignment** 
- Read LoginDataProvider class
- Read DataProviderBase
- Read ILoginDataProvider

## Day 14: January 15, 2020 Wednesday

**Today's Progress**:
- Research about DataProvider and Repository (e.g LoginDataProvider) _(https://stackoverflow.com/questions/25137518/dataprovider-vs-repository)_

**Thoughts:** 
Still trying to understand the design and I'll try to create a similar design to call an API 

## Day 15: January 16, 2020 Thursday

**Thoughts:** 
A possible project with a real user is in discussion from a friend. I will be a little project facilitator for this to help make a proposal MVP. 


