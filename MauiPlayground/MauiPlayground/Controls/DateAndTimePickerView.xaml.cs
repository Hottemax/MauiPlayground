namespace MauiPlayground.Controls;

/// <summary> View that gets passed a DateTime to BindableProperty DateAndTime, bind them to two Pickers and updates the original bound property accordingly </summary>
public partial class DateAndTimePickerView : ContentView
{
    public static readonly BindableProperty DateAndTimeProperty = BindableProperty.Create(nameof(DateAndTime), typeof(DateTime?), typeof(DateAndTimePickerView), default(DateTime), BindingMode.TwoWay, propertyChanged: DateAndTimeChanged);
    public static readonly BindableProperty LabelTextDateProperty = BindableProperty.Create(nameof(LabelTextDate), typeof(string), typeof(DateAndTimePickerView), "Date");
    public static readonly BindableProperty LabelTextTimeProperty = BindableProperty.Create(nameof(LabelTextTime), typeof(string), typeof(DateAndTimePickerView), "Time");
    public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(DateAndTimePickerView));

    private static void DateAndTimeChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is DateAndTimePickerView view
            && newValue is DateTime dt
            && oldValue != newValue)
        {
            Log.Debug($"DateAndTimeChanged from {oldValue} to {newValue}");
            view.DateOnly = dt.Date;
            view.TimeOnly = dt.TimeOfDay;
        }
    }

    public DateAndTimePickerView()
    {
        InitializeComponent();
    }

    public string LabelTextDate
    {
        get => (string)GetValue(LabelTextDateProperty);
        set => SetValue(LabelTextDateProperty, value);
    }

    public string LabelTextTime
    {
        get => (string)GetValue(LabelTextTimeProperty);
        set => SetValue(LabelTextTimeProperty, value);
    }

    public Color LabelColor
    {
        get => (Color)GetValue(LabelColorProperty);
        set => SetValue(LabelColorProperty, value);
    }

    public DateTime? DateAndTime
    {
        get => (DateTime?)GetValue(DateAndTimeProperty);
        set => SetValue(DateAndTimeProperty, value);
    }

    public DateTime? DateOnly
    {
        get => DateAndTime?.Date;
        set
        {
            DateAndTime = value?.Add(TimeOnly ?? TimeSpan.Zero);
            OnPropertyChanged(nameof(DateOnly));
            OnPropertyChanged(nameof(TimeOnly));
        }
    }

    /// <summary> TimeOnly is not independent of DateOnly, it will get cleared if we clear DateOnly.
    /// This behavior is desired, since having only a TimeOfDay with no Date has no valid DateTime semantics</summary>
    public TimeSpan? TimeOnly
    {
        get => DateAndTime?.TimeOfDay;
        set
        {
            DateAndTime = DateAndTime?.Date.Add(value ?? TimeSpan.Zero);
            OnPropertyChanged(nameof(TimeOnly));
        }
    }
}
