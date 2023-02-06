namespace MauiPlayground.ViewModels;

public partial class DateAndTimeViewModel :ObservableObject
{
    [ObservableProperty]
    public DateTime? _sampleDate = DateTime.Now;


    [ObservableProperty]
    public string _testString = "Test";

    partial void OnSampleDateChanged(DateTime? value)
    {
        Console.WriteLine($"SampleDate changed to {value}");
    }
}
