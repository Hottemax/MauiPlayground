namespace MauiPlayground.Controls;

/// <summary> View that combines an InputField and a Command that can fetch input for the Text of this Field from another page/dialog</summary>
public partial class CmdTextField : ContentView
{
    /// <summary> Label text </summary>
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CmdTextField), string.Empty);

    /// <summary> Entry text (usually a Binding) </summary>
    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(CmdTextField), string.Empty, BindingMode.TwoWay);

    /// <summary> ImageSource of the Icon </summary>
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(CmdTextField), default(ImageSource));

    /// <summary> Whether the Entry is read-only (default: false) </summary>
    public static readonly BindableProperty IsReadOnlyProperty = BindableProperty.Create(nameof(IsReadOnly), typeof(bool), typeof(CmdTextField), false);

    public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(CmdTextField), false);

    /// <summary> Specifies type of keyboard </summary>
    public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(CmdTextField), Keyboard.Default);

    /// <summary> Specifies max number of characters </summary>
    public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(CmdTextField), int.MaxValue);

    /// <summary> Bindable ICommand to be executed when clicking the button </summary>
    public static readonly BindableProperty CmdProperty = BindableProperty.Create(nameof(Cmd), typeof(ICommand), typeof(CmdTextField));

    /// <summary> Optional parameter for the ICommand </summary>
    public static readonly BindableProperty CmdParamProperty = BindableProperty.Create(nameof(CmdParam), typeof(string), typeof(CmdTextField), string.Empty);

    /// <summary> ImageSource of the button (default usually set in the ControlTemplate is "{StaticResource IconArrowRight}") </summary>
    public static readonly BindableProperty CmdIconProperty = BindableProperty.Create(nameof(CmdIcon), typeof(ImageSource), typeof(CmdTextField), default(ImageSource));

    public CmdTextField()
    {
        textField.Any();
        InitializeComponent();
    }

    public string Title { get => (string)GetValue(TitleProperty); set => SetValue(TitleProperty, value); }
    public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
    public ImageSource Icon { get => (ImageSource)GetValue(CmdIconProperty); set => SetValue(CmdIconProperty, value); }

    public bool IsReadOnly { get => (bool)GetValue(IsReadOnlyProperty); set => SetValue(IsReadOnlyProperty, value); }
    public bool IsPassword { get => (bool)GetValue(IsPasswordProperty); set => SetValue(IsPasswordProperty, value); }

    public Keyboard Keyboard { get => (Keyboard)GetValue(KeyboardProperty); set => SetValue(KeyboardProperty, value); }
    public int MaxLength { get => (int)GetValue(MaxLengthProperty); set => SetValue(MaxLengthProperty, value); }

    public ICommand Cmd { get => (ICommand)GetValue(CmdProperty); set => SetValue(CmdProperty, value); }
    public string CmdParam { get => (string)GetValue(CmdParamProperty); set => SetValue(CmdParamProperty, value); }
    public ImageSource CmdIcon { get => (ImageSource)GetValue(CmdIconProperty); set => SetValue(CmdIconProperty, value); }
}
