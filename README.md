# #100DaysOfCode (Round 2)

## Daily logs for R2

This is my second round of #100DaysOfCode. My focus for this round is to learn more about Xamarin, C# and Prism which my current bread and butter. The plan is to learn the basics of MVVM and prism and the end result of this challenge will be a xamarin version of my old native ios app. 

### Day 1: December 23, 2019 Monday

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

### Day 2: December 24, 2019 Tuesday

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
- BindableBase
- Dependecy Injection
    - https://www.theserverside.com/news/1321158/A-beginners-guide-to-Dependency-Injection

### Day 3: December 25, 2019 Wednesday

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

```

