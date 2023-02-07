namespace MauiPlayground.Pages;

public partial class DateAndTimeTestPage : UraniumUI.Pages.UraniumContentPage
{
    public DateAndTimeTestPage()
    {
        BindingContext = new DateAndTimeViewModel();
        Log.Debug("DateAndTimeTestPage constructor, InitializingComponent() ...");
        InitializeComponent();
        Log.Debug("DateAndTimeTestPage constructor, setting BindingContext to new DateAndTimeViewModel()");
       
        Log.Debug("DateAndTimeTestPage exiting constructor");
    }
}
