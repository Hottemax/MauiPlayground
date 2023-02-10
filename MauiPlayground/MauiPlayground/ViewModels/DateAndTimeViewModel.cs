namespace MauiPlayground.ViewModels;

public partial class DateAndTimeViewModel : ObservableObject
{
    [ObservableProperty]
    public DateTime? _sampleDate = DateTime.Now;

    [ObservableProperty]
    public DateTime? _someOtherDate = DateTime.Now;

    [ObservableProperty]
    public TimeSpan? _sampleTime = new(hours: 3, minutes: 14, seconds: 0);

    [ObservableProperty]
    public string _testStringDate = "TestDate";

    [ObservableProperty]
    public string _testStringTime = "TestTime";

    public DateAndTimeViewModel()
    {
        SampleDate = DateTime.Now;
    }
    partial void OnSampleDateChanged(DateTime? value)
    {
        Log.Debug($"SampleDate changed to {value}");
    }
}
