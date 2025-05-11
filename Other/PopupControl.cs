using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using static MaticeApp.Utils;

namespace MaticeApp
{
    public class PopupControl : ContentControl
    {
        private FrameworkElement? triggerElement;
        private FrameworkElement? placementTargetElement;
        private Popup? HoverPopup;
        private Border? BorderContentElement;
        public enum PopupHorizontalAlignment
        {
            Left, Right, Center
        }
        public PopupHorizontalAlignment popupHorizontalAlignment { get; set; } = PopupHorizontalAlignment.Center;



        public static readonly DependencyProperty TriggerElementProperty =
            DependencyProperty.Register(nameof(TriggerElement), typeof(FrameworkElement), typeof(PageParagraph));
        public FrameworkElement TriggerElement
        {
            get => (FrameworkElement)GetValue(TriggerElementProperty);
            set => SetValue(TriggerElementProperty, value);
        }


        public PopupControl()
        {
            Loaded += PopupControl_Loaded;
        }
        private void PopupControl_Loaded(object sender, RoutedEventArgs e)
        {
            // If TriggerContent is defined in XAML, use it as the trigger element
            if (TriggerElement != null)
            {
                SetTriggerElement(TriggerElement);
            }

            HoverPopup = Template.FindName("HoverPopup", this) as Popup;
            BorderContentElement = Template.FindName("BorderContentElement", this) as Border;

            if (BorderContentElement != null)
            {
                BorderContentElement.MouseLeave += OnPopupMouseLeave;
            }
        }


        public void SetTriggerElement(FrameworkElement trigger)
        {
            if (triggerElement != null)
            {
                triggerElement.MouseEnter -= OnTriggerElementMouseEnter;
                triggerElement.MouseLeave -= OnTriggerElementMouseLeave;
            }

            triggerElement = trigger;

            if (triggerElement != null)
            {
                triggerElement.MouseEnter += OnTriggerElementMouseEnter;
                triggerElement.MouseLeave += OnTriggerElementMouseLeave;
                if (placementTargetElement == null)
                    SetPlacementTarget(triggerElement);
            }
        }
        public void SetPlacementTarget(FrameworkElement placementTarget)
        {
            placementTargetElement = placementTarget;
            if (HoverPopup != null)
                HoverPopup.PlacementTarget = placementTargetElement ?? triggerElement;
        }

        public void SetPlacementMode(PlacementMode placementMode)
        {
            if (HoverPopup != null)
                HoverPopup.Placement = placementMode;
        }

        public void SetVerticalOffset(double value)
        {
            if (HoverPopup != null)
                HoverPopup.VerticalOffset = value;
        }


        // Event handler to show the popup on mouse enter
        private void OnTriggerElementMouseEnter(object sender, MouseEventArgs e)
        {
            if (HoverPopup == null) return;

            HoverPopup.IsOpen = true;

            if (placementTargetElement == null) return;

            if (HoverPopup.Placement == PlacementMode.Bottom || HoverPopup.Placement == PlacementMode.Top)
            {
                switch (popupHorizontalAlignment)
                {
                    case PopupHorizontalAlignment.Center:
                        HoverPopup.HorizontalOffset = (placementTargetElement.ActualWidth - BorderContentElement.ActualWidth) / 2;
                        break;
                    case PopupHorizontalAlignment.Left:
                        break;
                    case PopupHorizontalAlignment.Right:
                        HoverPopup.HorizontalOffset = placementTargetElement.ActualWidth - BorderContentElement.ActualWidth;
                        break;
                }
            }
            else
            {
                HoverPopup.HorizontalOffset = 0;
            }
        }

        private void OnPopupMouseLeave(object sender, MouseEventArgs e)
        {
            TryClosePopup();
        }

        // Event handler to hide the popup on mouse leave
        private void OnTriggerElementMouseLeave(object sender, MouseEventArgs e)
        {
            TryClosePopup();
        }

        private void TryClosePopup()
        {
            if (triggerElement == null || BorderContentElement == null || HoverPopup == null)
                return;

            if (!triggerElement.IsMouseOver && !BorderContentElement.IsMouseOver)
            {
                HoverPopup.IsOpen = false;
            }
        }


    }
}
