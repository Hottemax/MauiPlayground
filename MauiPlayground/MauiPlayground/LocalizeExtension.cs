using MauiPlayground.Resources.Strings;
using Microsoft.Extensions.Localization;

namespace MauiPlayground;

[ContentProperty(nameof(Key))]
public class LocalizeExtension : IMarkupExtension<string>
{
    IStringLocalizer<MyStrings> _localizer;

    public string Key { get; set; } = string.Empty;

    public LocalizeExtension()
    {
        _localizer = ServiceHelper.GetService<IStringLocalizer<MyStrings>>();
    }

    public string ProvideValue(IServiceProvider serviceProvider)
    {
        string localizedText = _localizer[Key];
        return localizedText;
    }

    object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
}
