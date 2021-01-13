using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Styling;

namespace Polcraz.GoogleChromeWindow.AvaloniaUI
{
    public class ChromeTabsControl : ListBox, IStyleable
    {
        Type IStyleable.StyleKey => typeof(ChromeTabsControl);
    }
}