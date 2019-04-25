using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if(cbDefaultTest.TintColor == Color.Default)
			{
				cbDefaultTest.TintColor = Color.Green;
				cbDefaultTest2.TintColor = Color.Green;
			}
			else
			{
				cbDefaultTest.TintColor = Color.Default;
				cbDefaultTest2.TintColor = Color.Default;
			}
		}
	}
}