using System.ComponentModel.DataAnnotations;

namespace MauiPlayground.ViewModels;
// Trying to replicate login page so that all functionalities of entry control can be tested.
internal partial class EntryViewModel : ObservableValidator
{

    [Required]
    [ObservableProperty]
    private string _name;
    [Required]
    [ObservableProperty]
    private string _password;
    public List<string> Dbs { get; set; } = new List<string> { "test1", "test2" };
    [ObservableProperty]
    private bool _isPickerVisible = false;
    public Command DbCommand => new(GetDb);
    // Somehow relaycommand is not working with toollkit:eventtocommand` need to invstigate further
    //[RelayCommand]
    public void GetDb() => IsPickerVisible = true;
}
