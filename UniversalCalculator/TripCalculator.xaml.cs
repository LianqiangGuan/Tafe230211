using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class TripCalculator : Page
	{
		public TripCalculator()
		{
			this.InitializeComponent();
		}
		private void todayDateButton_Click(object sender, RoutedEventArgs e)
		{

			DateTime todayDate = DateTime.Today;

			todayDateTextBlock.Text = todayDate.ToString("dd-MM-yyyy");

		}

		private async void calTotal_Click(object sender, RoutedEventArgs e)
		{
			int hireDay;
			double dayPrice;
			double amountToPay;
			try
			{
				hireDay = int.Parse(dayHireNumTextBox.Text);
			}
			catch (Exception exc)
			{
				var dialogMessage = new MessageDialog("Error in Number of day textbox " + exc.Message);
				await dialogMessage.ShowAsync();
				return;
			}
			try
			{
				dayPrice = double.Parse(dayPriceTextBox.Text);
			}
			catch (Exception exc)
			{
				var dialogMessage = new MessageDialog("Error in Price per day textbox " + exc.Message);
				await dialogMessage.ShowAsync();
				return;
			}
			//hireDay = int.Parse(dayHireNumTextBox.Text);
			//dayPrice = double.Parse(dayPriceTextBox.Text);
			amountToPay = hireDay * dayPrice;

			payAmountTextBox.Text = amountToPay.ToString("C");

		}

		private void exit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu), null);
		}
	}
}
