namespace MauiPlayground.Controls;

/// <summary> View that gets passed a DateTime to BindableProperty DateAndTime, bind them to two Pickers and update the original bound property accordingly </summary>
public partial class DateAndTimePickerView : ContentView
{
    private DateTime? _dateOnly;
    private TimeSpan? _timeOnly;

    public static readonly BindableProperty DateAndTimeProperty = BindableProperty.Create(nameof(DateAndTime), typeof(DateTime?), typeof(DateAndTimePickerView), default(DateTime), BindingMode.TwoWay);
    public static readonly BindableProperty LabelTextDateProperty = BindableProperty.Create(nameof(LabelTextDate), typeof(string), typeof(DateAndTimePickerView), string.Empty);
    public static readonly BindableProperty LabelTextTimeProperty = BindableProperty.Create(nameof(LabelTextTime), typeof(string), typeof(DateAndTimePickerView), string.Empty);
    public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(DateAndTimePickerView));

    public DateAndTimePickerView()
    {
        InitializeComponent();
        // TODO Check why the bindings work Source={x:Reference self} in xaml, but not with BindingContext ...
        //BindingContext = this;

        //TODO Constructor will not be relevant when initialized via Binding
        _dateOnly = DateAndTime?.Date;
        _timeOnly = DateAndTime?.TimeOfDay;
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
        get => _dateOnly;
        set
        {
            DateAndTime = value?.Add(TimeOnly.Value);
            UpdateDateTime();
        }
    }

    public TimeSpan? TimeOnly
    {
        get => _timeOnly;
        set
        {
            _timeOnly = value;
            UpdateDateTime();
        }
    }

    private void UpdateDateTime()
    {
        // TODO Logic: Update of DateOnly, TimeOnly only on first initialization, then one way to DateAndTime ...
        DateAndTime = (DateOnly, TimeOnly) switch
        {
            (null, _) => null,
            (var date, null) => date,
            (var date, var time) => date.Value.Add(time.Value),
        };
    }
}
