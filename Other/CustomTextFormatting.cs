using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MaticeApp
{
    public abstract class CustomSpan : Span
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(CustomSpan),
                new PropertyMetadata(string.Empty, OnTextChanged));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        protected static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomSpan control && e.NewValue is string text)
            {
                control.UpdateFormattedText(text);
            }
        }

        protected abstract void UpdateFormattedText(string text);
    }

    public abstract class SubscriptSuperscriptSpan : CustomSpan
    {
        protected override void UpdateFormattedText(string text)
        {
            Inlines.Clear(); // Clear previous content

            if (string.IsNullOrEmpty(text))
                return;

            // Start grouping characters by their type (letters or non-letters)
            int startIndex = 0;
            bool isCurrentLetter = char.IsLetter(text[0]);

            for (int i = 1; i < text.Length; i++)
            {
                // Check if the current character matches the current group type
                if (char.IsLetter(text[i]) != isCurrentLetter)
                {
                    // Create a Run for the current group
                    AddRun(text.Substring(startIndex, i - startIndex), isCurrentLetter);

                    // Update group type and start index
                    startIndex = i;
                    isCurrentLetter = char.IsLetter(text[i]);
                }
            }

            // Add the last group
            AddRun(text.Substring(startIndex), isCurrentLetter);
        }

        protected void AddRun(string content, bool isLetter)
        {
            Run run = new Run(content)
            {
                FontSize = isLetter ? 14 : 13, // Different FontSize for letters and other characters
                FontStyle = isLetter ? FontStyles.Italic : FontStyles.Normal, // Italic for letters
            };

            Inlines.Add(run);
        }
    }

    public class SubscriptSpan : SubscriptSuperscriptSpan
    {
        public SubscriptSpan()
        {
            this.BaselineAlignment = BaselineAlignment.Subscript;
        }
    }

    public class SuperscriptSpan : SubscriptSuperscriptSpan
    {
        public SuperscriptSpan()
        {
            this.BaselineAlignment = BaselineAlignment.TextTop;
        }
    }

    public class MatrixNameSpan : CustomSpan
    {
        protected override void UpdateFormattedText(string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            Inlines.Clear();

            text.Trim();

            Inlines.Add(new Run(text[0].ToString()) { FontWeight = FontWeights.SemiBold });

            if (text.Length < 3) return;
            
            if (text[1] == '_')
                Inlines.Add(new SubscriptSpan() { Text = text.Substring(2) });
            else if (text[1] == '^')
                Inlines.Add(new SuperscriptSpan() { Text = text.Substring(2) });
        }
    }

    public class MatrixElementSpan : CustomSpan
    {
        protected override void UpdateFormattedText(string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            Inlines.Clear();

            text.Trim();

            Inlines.Add(new Run(text[0].ToString()) { FontStyle = FontStyles.Italic });

            if (text.Length < 3) return;

            if (text[1] == '_')
                Inlines.Add(new SubscriptSpan() { Text = text.Substring(2) });
            else if (text[1] == '^')
                Inlines.Add(new SuperscriptSpan() { Text = text.Substring(2) });
        }
    }

    public class RunItalic : Run
    {
        public RunItalic()
        {
            this.FontStyle = FontStyles.Italic;
        }
    }

    public class RunSemiBold : Run
    {
        public RunSemiBold()
        {
            this.FontWeight = FontWeights.SemiBold;
        }
    }

    public class HighlightBorder : Border
    {
        public HighlightBorder()
        {
            Padding = new Thickness(2);
            Margin = new Thickness(-4); // - (Padding + BorderThickness)

            BorderThickness = new Thickness(2);
            BorderBrush = new SolidColorBrush(Color.FromArgb(180, 216, 245, 255));

            Background = new SolidColorBrush(Color.FromArgb(189, 240, 255, 255));

            CornerRadius = new CornerRadius(5);
        }
    }

    public class StackPanelHorizontal : StackPanel
    {
        public StackPanelHorizontal()
        {
            Orientation = Orientation.Horizontal;
        }

        protected override void OnVisualChildrenChanged(DependencyObject visualAdded, DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            
            if (visualAdded is FrameworkElement element)
            {
                element.VerticalAlignment = VerticalAlignment.Center;
            }
        }
    }

    public class PagePanel : Border
    {
        public PagePanel()
        {
            Padding = new Thickness(10);
            BorderThickness = new Thickness(3);
            BorderBrush = Brushes.LightBlue;
            CornerRadius = new CornerRadius(10);
        }
    }

    /// <summary>
    /// Replaces every space with a non-breaking space symbol
    /// </summary>
    public class NoBreakSpan : Span
    {
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ProcessInlines(Inlines);
        }

        private void ProcessInlines(InlineCollection inlines)
        {
            // Iterate through all Inline elements
            foreach (var inline in inlines.ToArray())
            {
                if (inline is Run run)
                    run.Text = run.Text.Replace(" ", "\u00A0");
                else if (inline is Span span)
                    ProcessInlines(span.Inlines); // Recursively process nested Span elements
            }
        }
    }

    public class TooltipSpan : Span
    {
        public TooltipSpan()
        {
            Cursor = Cursors.Hand;
            Foreground = new SolidColorBrush(Color.FromArgb(255, 21, 79, 133));
            ToolTipService.SetInitialShowDelay(this, 0);
        }
    }
}
