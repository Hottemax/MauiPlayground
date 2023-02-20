using System.Windows.Input;

namespace MauiPlayground.Controls;

/// <summary> View that gets passed a DateTime to BindableProperty DateAndTime, bind them to two Pickers and updates the original bound property accordingly </summary>
public partial class LabeledEntry : ContentView
{
    /// <summary> Label text </summary>
    public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(LabeledEntry), string.Empty);

    /// <summary> Entry text (usually a Binding) </summary>
    public static readonly BindableProperty EntryTextProperty = BindableProperty.Create(nameof(EntryText), typeof(string), typeof(LabeledEntry), string.Empty, BindingMode.TwoWay);

    /// <summary> Allows styling the entry with a Style </summary>
    public static readonly BindableProperty EntryStyleProperty = BindableProperty.Create(nameof(EntryStyle), typeof(Style), typeof(LabeledEntry));

    /// <summary> Whether the Entry is enabled (default: true) </summary>
    public static readonly BindableProperty EntryEnabledProperty = BindableProperty.Create(nameof(EntryEnabled), typeof(bool), typeof(LabeledEntry), true);
    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(LabeledEntry), false);

    /// <summary> Whether the Entry is read-only (default: false) </summary>
    public static readonly BindableProperty ReadOnlyProperty = BindableProperty.Create(nameof(ReadOnly), typeof(bool), typeof(LabeledEntry), false);

    /// <summary> Text to show in valdation message text box (default: string.Empty) </summary>
    public static readonly BindableProperty ValidationMessageProperty = BindableProperty.Create(nameof(ValidationMessage), typeof(string), typeof(LabeledEntry), string.Empty);

    /// <summary> Bindable ICommand to be executed when clicking the button </summary>
    public static readonly BindableProperty CmdProperty = BindableProperty.Create(nameof(Cmd), typeof(ICommand), typeof(LabeledEntry));

    /// <summary> Optional parameter for the ICommand </summary>
    public static readonly BindableProperty CmdParamProperty = BindableProperty.Create(nameof(CmdParam), typeof(string), typeof(LabeledEntry), string.Empty);

    /// <summary> ImageSource of the button (default usually set in the ControlTemplate is "{StaticResource IconArrowRight}") </summary>
    public static readonly BindableProperty CmdButtonImageProperty = BindableProperty.Create(nameof(CmdButtonImage), typeof(ImageSource), typeof(LabeledEntry), default(ImageSource));

    /// <summary> TextColor of the label (applicable for example to visually show that fields are required) </summary>
    public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(LabeledEntry));

    /// <summary> TextColor of the label (applicable for example to visually show that fields are required) </summary>
    public static readonly BindableProperty LabelBackgroundProperty = BindableProperty.Create(nameof(LabelBackground), typeof(Color), typeof(LabeledEntry), Colors.White);

    /// <summary> BorderColor of the Frame </summary>
    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(LabeledEntry), Colors.LightGray);

    /// <summary> Specifies type of keyboard </summary>
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(LabeledEntry), Keyboard.Default);

    /// <summary> Specifies max number of characters </summary>
    public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(LabeledEntry), int.MaxValue);

    /// <summary> Whether to show error message or not </summary>
    public static readonly BindableProperty ShowErrorProperty = BindableProperty.Create(nameof(ShowError), typeof(bool), typeof(LabeledEntry), false);

    /// <summary> Color of the entry text </summary>
    public static readonly BindableProperty EntryTextColorProperty = BindableProperty.Create(nameof(EntryTextColor), typeof(Color), typeof(LabeledEntry), Colors.Black);

    public LabeledEntry()
    {
        InitializeComponent();
    }

    public Color EntryTextColor { get => (Color)GetValue(EntryTextColorProperty); set => SetValue(EntryTextColorProperty, value); }

    public string LabelText { get => (string)GetValue(LabelTextProperty); set => SetValue(LabelTextProperty, value); }

    public Color LabelBackground { get => (Color)GetValue(LabelBackgroundProperty); set => SetValue(LabelBackgroundProperty, value); }

    public Keyboard Keyboard { get => (Keyboard)GetValue(KeyboardProperty); set => SetValue(KeyboardProperty, value); }
    public int MaxLength { get => (int)GetValue(MaxLengthProperty); set => SetValue(MaxLengthProperty, value); }
    public string EntryText { get => (string)GetValue(EntryTextProperty); set => SetValue(EntryTextProperty, value); }

    public Style EntryStyle { get => (Style)GetValue(EntryStyleProperty); set => SetValue(EntryStyleProperty, value); }
    public bool EntryEnabled { get => (bool)GetValue(EntryEnabledProperty); set => SetValue(EntryEnabledProperty, value); }
    public bool IsPassword { get => (bool)GetValue(IsPasswordProperty); set => SetValue(IsPasswordProperty, value); }
    public bool ReadOnly { get => (bool)GetValue(ReadOnlyProperty); set => SetValue(ReadOnlyProperty, value); }
    public string ValidationMessage { get => (string)GetValue(ValidationMessageProperty); set => SetValue(ValidationMessageProperty, value); }

    public ICommand Cmd { get => (ICommand)GetValue(CmdProperty); set => SetValue(CmdProperty, value); }
    public string CmdParam { get => (string)GetValue(CmdParamProperty); set => SetValue(CmdParamProperty, value); }
    public ImageSource CmdButtonImage { get => (ImageSource)GetValue(CmdButtonImageProperty); set => SetValue(CmdButtonImageProperty, value); }
    public Color LabelColor { get => (Color)GetValue(LabelColorProperty); set => SetValue(LabelColorProperty, value); }
    public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }
    public bool ShowError { get => (bool)GetValue(ShowErrorProperty); set => SetValue(ShowErrorProperty, value); }
}
