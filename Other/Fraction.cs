using System.Windows;
using System.Windows.Controls;

namespace MaticeApp
{
    public class Fraction : ContentControl
    {
        public static readonly DependencyProperty NumeratorProperty =
            DependencyProperty.Register(nameof(Numerator), typeof(FrameworkElement), typeof(PageParagraph));
        public FrameworkElement Numerator
        {
            get => (FrameworkElement)GetValue(NumeratorProperty);
            set => SetValue(NumeratorProperty, value);
        }

        public static readonly DependencyProperty DenominatorProperty =
            DependencyProperty.Register(nameof(Denominator), typeof(FrameworkElement), typeof(PageParagraph));
        public FrameworkElement Denominator
        {
            get => (FrameworkElement)GetValue(DenominatorProperty);
            set => SetValue(DenominatorProperty, value);
        }
    }
}
