using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Xamarin.Forms.Platform.UWP
{
	public class CheckBoxRenderer : ViewRenderer<CheckBox, FormsCheckBox>
	{
		Brush _tintDefaultBrush = Color.Blue.ToBrush();

		protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					var control = new FormsCheckBox() {
						Style = Windows.UI.Xaml.Application.Current.Resources["FormsCheckBoxStyle"] as Windows.UI.Xaml.Style
					   };

					control.Checked += OnNativeChecked;
					control.Unchecked += OnNativeChecked;
					//control.ClearValue(WindowsCheckbox.IsCheckedProperty);

					SetNativeControl(control);
				}

				Control.IsChecked = Element.IsChecked;
				
				UpdateFlowDirection();
				UpdateTintColor();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == CheckBox.IsCheckedProperty.PropertyName)
			{
				Control.IsChecked = Element.IsChecked;
			}
			else if (e.PropertyName == VisualElement.FlowDirectionProperty.PropertyName)
			{
				UpdateFlowDirection();
			}
			else if(e.PropertyName == CheckBox.TintColorProperty.PropertyName)
			{
				UpdateTintColor();
			}
		}

		protected override bool PreventGestureBubbling { get; set; } = true;

		void OnNativeChecked(object sender, RoutedEventArgs routedEventArgs)
		{
			((IElementController)Element).SetValueFromRenderer(CheckBox.IsCheckedProperty, Control.IsChecked);
		}

		void UpdateFlowDirection()
		{
			Control.UpdateFlowDirection(Element);
		}

		void UpdateTintColor()
		{
			BrushHelpers.UpdateColor(Element.TintColor, ref _tintDefaultBrush,
				() => Control.TintBrush, brush => Control.TintBrush = brush);
			
		}
	}
}