namespace MauiPlayground;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        themeSwitch.IsToggled = Application.Current.RequestedTheme == AppTheme.Dark;
        Application.Current.RequestedThemeChanged += (s, e) => themeSwitch.IsToggled = Application.Current.RequestedTheme == AppTheme.Dark;
    }

    private void ThemeToggled(object sender, ToggledEventArgs e)
    {
        Application.Current.UserAppTheme = e.Value ? AppTheme.Dark : AppTheme.Light;
    }
}
