using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
	public sealed partial class CurrencyCalculator : Page
	{
		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}
		private void CalculateButton_Click(object sender, RoutedEventArgs e)
		{
			try
			{

				if (double.TryParse(AmountTextBox.Text, out double amount) &&
					FromComboBox.SelectedItem != null &&
					ToComboBox.SelectedItem != null)
				{
					// Get the selected currencies
					string sourceCurrency = ((ComboBoxItem)FromComboBox.SelectedItem).Content.ToString();
					string targetCurrency = ((ComboBoxItem)ToComboBox.SelectedItem).Content.ToString();




					double exchangeRate = GetExchangeRate(sourceCurrency, targetCurrency);



					// Calculate the converted amount
					double convertedAmount = amount * exchangeRate;



					// Display the result
					ResultTextBlock.Text = $"{amount} {sourceCurrency} is equivalent to {convertedAmount:F2} {targetCurrency}";
				}
				else
				{
					// Display an error message if input is not valid
					ResultTextBlock.Text = "Invalid input. Please enter numeric values and select currencies.";
				}
			}
			catch (Exception ex)
			{

				ResultTextBlock.Text = $"An error occurred: {ex.Message}";
			}
		}




		private double GetExchangeRate(string sourceCurrency, string targetCurrency)
		{
			// Using exchange rates.

			if (sourceCurrency == "USD" && targetCurrency == "EUR")
				return 0.85;
			else if (sourceCurrency == "USD" && targetCurrency == "GBP")
				return 0.72;
			else if (sourceCurrency == "USD" && targetCurrency == "INR")
				return 74.15;
			else if (sourceCurrency == "EUR" && targetCurrency == "USD")
				return 1.18;
			else if (sourceCurrency == "EUR" && targetCurrency == "INR")
				return 87.00;
			else if (sourceCurrency == "EUR" && targetCurrency == "GBP")
				return 0.85;
			else if (sourceCurrency == "GBP" && targetCurrency == "USD")
				return 1.37;
			else if (sourceCurrency == "GBP" && targetCurrency == "EUR")
				return 1.16;
			else if (sourceCurrency == "GBP" && targetCurrency == "INR")
				return 101.68;
			else if (sourceCurrency == "INR" && targetCurrency == "USD")
				return 0.011;
			else if (sourceCurrency == "INR" && targetCurrency == "EUR")
				return 0.013;
			else if (sourceCurrency == "INR" && targetCurrency == "GBP")
				return 0.009;




			// Default to 1.0 if no conversion rate is available
			return 1.0;
		}

		private void ExitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}
	}
}

