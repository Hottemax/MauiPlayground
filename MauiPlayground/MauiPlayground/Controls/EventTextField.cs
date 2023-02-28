using UraniumUI.Material.Controls;

namespace MauiPlayground.Controls;

/// <summary>
/// TextField delegating events ...
/// </summary>
public class EventTextField : TextField
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
