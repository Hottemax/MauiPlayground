using UraniumUI.Material.Controls;

namespace MauiPlayground.Controls;
// <Summary> Existing textfield does not invoke unfocused event so need to extend it.
public class BorderLessEntry : TextField
{
    public new event EventHandler<FocusEventArgs> Unfocused;
    protected override void OnHandlerChanged()
    {
        EntryView.Unfocused += EntryView_Unfocused;
        if (Handler is null)
        {
            EntryView.Unfocused -= EntryView_Unfocused;
        }
    }

    private void EntryView_Unfocused(object sender, FocusEventArgs e)
    {
        if (!e.IsFocused)
        {
            Unfocused?.Invoke(sender, e);
        }
    }
}
