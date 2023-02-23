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


    [RelayCommand]
    public void Sample(string moo)
    {
        Name += "C";
        Log.Debug("SampleCommandInvoked");
    }
}
