using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using static MaticeApp.Utils;

namespace MaticeApp
{
    public class PageParagraph : ContentControl
    {
        // Dependency Property for Title
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(object), typeof(PageParagraph));

        public object Title
        {
            get => GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

    }
}
