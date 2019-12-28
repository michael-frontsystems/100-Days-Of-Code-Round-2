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
-**BindableBase**
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

    `````
    
  ### Day 4: December 26, 2019 Thursday

    **Today's Progress**: 

    *Set up Prism TabbedPage (https://xamgirl.com/prism-in-xamarin-forms-step-by-step-part-4/) 
    - Created a tabbedpage class as Parent of the 2 or more content pages. (e.g CustomTabbedPage.cs) 
    - Then I added two new ViewPages to be children of the CustomTabbedPage. (e.g Test1Page, Test2Page)
    - Register the following views in App.cs
    - Add header ui for both children as a temporary Navigation bar
    - Add temporary icons to each tab (e.g Idea and Settings)

**Thoughts:** I started using tabbed page in PRISM as an investigation on how to use it and also to get an initial idea on how can I apply this approach to UserVIewPage in Cornerstone. Its all visual changes in today's progress but I will investigate more if NavigationAware methods will still work on a tabbed page setup.

**Assignment** 
Investigate about the folowing:
- If NavigationAware methods still work on Tabbed Page Setup
- If IDestructible methods still work on Tabbed Page Setup
- Parameter passing when navigating

  ### Day 5: December 28, 2019 Saturday

    **Today's Progress**: 
    - Fix Navigation for login and for calling a child view 
        - _(Navigation as PUSH) await _navigationService.NavigateAsync(new System.Uri("/NavigationPage/CustomTabbedPage/HomePage"));_
        - _(Navigation as MODAL) await _navigationService.NavigateAsync("/NavigationPage/CustomTabbedPage/HomePage");_

**Thoughts:** Fix all navigation since all my previous calling of new page are animated from bottom to top which is like calling a  Modal View (in native). It is a little confusing because I was still on "native way" of thinking and Xamarin + Prism has its own way of calling views and it seems simple but needs more attention to how we use NavigateAsync. 

**Assignment** 
Investigate about the folowing:
- If NavigationAware methods still work on Tabbed Page Setup
- If IDestructible methods still work on Tabbed Page Setup
- Parameter passing when navigating
