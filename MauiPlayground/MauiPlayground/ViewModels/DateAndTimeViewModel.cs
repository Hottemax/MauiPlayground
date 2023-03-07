namespace MauiPlayground.ViewModels;

public partial class DateAndTimeViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(TimeOfSampleDate))]
    public DateTime? _sampleDate = DateTime.Now;

    public TimeSpan? TimeOfSampleDate => SampleDate.HasValue ? SampleDate.Value.TimeOfDay : null;

    [ObservableProperty]
    public TimeSpan? _sampleTime = new(hours: 3, minutes: 14, seconds: 0);

    [ObservableProperty]
    public string _testStringDate = "TestDate";

    [ObservableProperty]
    public string _testStringTime = "TestTime";

    public DateAndTimeViewModel()
    {
    }
    partial void OnSampleDateChanged(DateTime? value)
    {
        Log.Debug($"SampleDate changed to {value}");
    }

    [RelayCommand]
    public void SetToNull() => SampleDate = null;

    [RelayCommand]
    public void SetToNewYear() => SampleDate = new(year: 2023, month: 1, day: 1, hour: 1, minute: 2, second: 0);

    [RelayCommand]
    public void SetToNow() => SampleDate = DateTime.Now;
}
