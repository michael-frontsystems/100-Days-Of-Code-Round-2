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
