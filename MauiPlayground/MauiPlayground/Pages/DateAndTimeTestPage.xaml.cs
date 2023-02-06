namespace MauiPlayground.Pages;

public partial class DateAndTimeTestPage : UraniumUI.Pages.UraniumContentPage
{
    public DateAndTimeTestPage()
    {
        InitializeComponent();
        BindingContext = new DateAndTimeViewModel();
    }
}
