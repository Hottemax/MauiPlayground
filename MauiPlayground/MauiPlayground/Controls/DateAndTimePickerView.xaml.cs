namespace MauiPlayground.Controls;

/// <summary> View that gets passed a DateTime to BindableProperty DateAndTime, bind them to two Pickers and update the original bound property accordingly </summary>
public partial class DateAndTimePickerView : ContentView
{
    private DateTime? _dateOnly;
    private TimeSpan? _timeOnly;

    public static readonly BindableProperty DateAndTimeProperty = BindableProperty.Create(nameof(DateAndTime), typeof(DateTime?), typeof(DateAndTimePickerView), default(DateTime), BindingMode.TwoWay);
    public static readonly BindableProperty LabelTextDateProperty = BindableProperty.Create(nameof(LabelTextDate), typeof(string), typeof(DateAndTimePickerView), "TEXTDATEDEFAULT");
    public static readonly BindableProperty LabelTextTimeProperty = BindableProperty.Create(nameof(LabelTextTime), typeof(string), typeof(DateAndTimePickerView), string.Empty);
    public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(DateAndTimePickerView));

    public DateAndTimePickerView()
    {
        InitializeComponent();
        // TODO Check why the bindings work Source={x:Reference self} in xaml, but not with BindingContext ...
        //BindingContext = this;
        Log.Debug($"After constructor, _dateOnly is {_dateOnly}");
    }
    public string LabelTextDate
    {
        get
        {
            var val = (string)GetValue(LabelTextDateProperty);
            Log.Debug($"LabelTextDate get called, returning {val}");
            return val;
        }

        set
        {
            Log.Debug($"LabelTextDate set called with value {value}");
            SetValue(LabelTextDateProperty, value);
        }
    }

    public string LabelTextTime
    {
        get
        {
            var val = (string)GetValue(LabelTextTimeProperty);
            Log.Debug($"LabelTextTime get called, returning {val}");
            return val;
        }

        set
        {
            Log.Debug($"LabelTextTime set called with value {value}");
            SetValue(LabelTextTimeProperty, value);
        }
    }

    public Color LabelColor
    {
        get
        {
            var val =  (Color)GetValue(LabelColorProperty);
            Log.Debug($"LabelTextColor get called, returning {val}");
            return val;
        }

        set
        {
            Log.Debug($"LabelColor set called with value {value}");
            SetValue(LabelColorProperty, value);
        }
    }

    public DateTime? DateAndTime
    {
        get
        {
            var val =  (DateTime?)GetValue(DateAndTimeProperty);
            Log.Debug($"DateAndTime get called, returning {val}");
            if (val is DateTime initialValue && _dateOnly is null && _timeOnly is null)
            {
                // Called only on initialization
                Log.Debug($"Initializing backing stores _dateOnly, _timeOnly");
                _dateOnly = initialValue.Date;
                _timeOnly = initialValue.TimeOfDay;
            }

            return val;
        }

        set
        {
            Log.Debug($"DateAndTime set called with value {value}");
            SetValue(DateAndTimeProperty, value);
        }
    }

    public DateTime? DateOnly
    {
        get
        {
            Log.Debug($"DateOnly get called, returning {_dateOnly}");
            return _dateOnly;
        }

        set
        {
            Log.Debug($"DateOnly set called with value {value}");
            _dateOnly = value;
            UpdateDateTime();
        }
    }

    public TimeSpan? TimeOnly
    {
        get
        {
            Log.Debug($"TimeOnly get called, returning {_timeOnly}");
            return _timeOnly;
        }

        set
        {
            Log.Debug($"TimeOnly set called with value {value}");
            _timeOnly = value;
            UpdateDateTime();
        }
    }

    private void UpdateDateTime()
    {

        Log.Debug($"UpdateDateTime() called, current state: DateOnly: {DateOnly}, TimeOnly: {TimeOnly}");
        // TODO Logic: Update of DateOnly, TimeOnly only on first initialization, then one way to DateAndTime ...
        DateAndTime = (DateOnly, TimeOnly) switch
        {
            (null, _) => null,
            (var date, null) => date,
            (var date, var time) => date.Value.Add(time.Value),
        };
        Log.Debug($"UpdateDateTime() set DateAndTime to {DateAndTime}");
    }
}
