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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			int principal = 0;
			int years = 0;
			int months = 0;
			int numberOfMonths = 0;
			const int MONTHS_IN_YEAR = 12;

			double annualInterestRate = 0;
			double monthlyInterestRate = 0;
			double monthlyRepayment = 0;
			double monthlyRepaymentCalculationNumerator = 0;
			double monthlyRepaymentCalculationDenominator = 0;

			// Make sure that the principle is an integer value
			try
			{
				principal = int.Parse(princBorrTextBox.Text);
			}
			catch (Exception theException)
			{
				var principalNotFloatDialogMessage = new MessageDialog("Error! Please enter an integer value only for Principal borrowed. " + theException.Message);//generates a message
				await principalNotFloatDialogMessage.ShowAsync();//outputs message in a pop up window
				princBorrTextBox.Focus(FocusState.Programmatic);// highlights principal borrow text box
				princBorrTextBox.SelectAll();// highlights principal borrow text box
				return;//returns back to xaml page
			}



			// Make sure that the number of years of the loan is an integer
			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch (Exception theException)
			{
				var yearsNotIntegerialogMessage = new MessageDialog("Error! Please enter an integer value for Years. " + theException.Message);//generates a message
				await yearsNotIntegerialogMessage.ShowAsync();//outputs message in a pop up window
				yearsTextBox.Focus(FocusState.Programmatic);// highlights years text box
				yearsTextBox.SelectAll();// highlights years text box
				return;//returns back to xaml page
			}



			// make sure that the number of months is an integer
			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch (Exception theException)
			{
				var monthsNotIntegerDialogMessage = new MessageDialog("Error! Please enter an integer value for Months. " + theException.Message);//generates a message
				await monthsNotIntegerDialogMessage.ShowAsync();//outputs message in a pop up window
				monthsTextBox.Focus(FocusState.Programmatic);// highlights months text box
				monthsTextBox.SelectAll();// highlights months text box
				return;//returns back to xaml page
			}


			// Make sure that the annual interest rate is a double value
			try
			{
				annualInterestRate = double.Parse(yearlyIntTextBox.Text);
			}
			catch (Exception theException)
			{
				var annualInterestRateNotDoubleDialogMessage = new MessageDialog("Error! Please enter a float value for Annual Interest Rate. " + theException.Message);//generates a message
				await annualInterestRateNotDoubleDialogMessage.ShowAsync();//outputs message in a pop up window
				yearlyIntTextBox.Focus(FocusState.Programmatic);// highlights yearly interest rate text box
				yearlyIntTextBox.SelectAll();// highlights yearly interest rate text box
				return;//returns back to xaml page
			}
			// check that the amount borrowed is at least $10,000
			if ((principal < 10000) || principal.ToString() == "")
			{
				var principalTooLowDialogMessage = new MessageDialog("Please enter a Principle borrowed value of at least $10,000");//generates a message
				await principalTooLowDialogMessage.ShowAsync();//outputs message in a pop up window
				princBorrTextBox.Focus(FocusState.Programmatic);// highlights principal borrow text box
				princBorrTextBox.SelectAll();// highlights principal borrow text box
				return;//returns back to xaml page
			}

			// Check that the number of years of the loan is between 5 and 40 yers inclusive
			if ((years < 5 || years > 40) || years.ToString() == "")
			{
				var yearsOutOfRangeDialogMessage = new MessageDialog("Please enter valid years in range >= 5 and <= 40");//generates a message
				await yearsOutOfRangeDialogMessage.ShowAsync();//outputs message in a pop up window
				yearsTextBox.Focus(FocusState.Programmatic);// highlights principal borrow text box
				yearsTextBox.SelectAll();// highlights principal borrow text box
				return;//returns back to xaml page
			}

			// Check that the number of months entered is between 0 and 11 months
			if ((months < 0 || months > 11) || months.ToString() == "")
			{
				var monthsOutOfRangeDialogMessage = new MessageDialog("Please enter valid Months in range >= 0 and <= 11");//generates a message
				await monthsOutOfRangeDialogMessage.ShowAsync();//outputs message in a pop up window
				monthsTextBox.Focus(FocusState.Programmatic);// highlights  months text box
				monthsTextBox.SelectAll();// highlights months text box
				return;//returns back to xaml page
			}

			// Ensure that the annual interest rate is a positive value
			if ((annualInterestRate <= 0) || annualInterestRate.ToString() == "")
			{
				var annualInterestRateTooLowwDialogMessage = new MessageDialog("Please enter valid Annual Interest Rate > 0%");//generates a message
				await annualInterestRateTooLowwDialogMessage.ShowAsync();//outputs message in a pop up window
				yearlyIntTextBox.Focus(FocusState.Programmatic);// highlights yearly interest rate text box
				yearlyIntTextBox.SelectAll();// highlights yearly interest rate text box
				return;//returns back to xaml page
			}

			// Calculate monthly interest rate
			monthlyInterestRate = annualInterestRate / MONTHS_IN_YEAR;

			monthlyIntTextBox.Text = monthlyInterestRate.ToString() + "%";

			monthlyInterestRate = monthlyInterestRate * 0.01;

			// Calculate number of months
			numberOfMonths = (years * 12) + months;

			// Calculate NUMERATOR of Monthly Repayment Calculation
			monthlyRepaymentCalculationNumerator = principal * (Math.Pow(1 + monthlyInterestRate, numberOfMonths)) * monthlyInterestRate;

			// Calculate NUMERATOR of Monthly Repayment Calculation
			monthlyRepaymentCalculationDenominator = Math.Pow(1 + monthlyInterestRate, numberOfMonths) - 1;

			// Calculate Monthly Repayment
			monthlyRepayment = monthlyRepaymentCalculationNumerator / monthlyRepaymentCalculationDenominator;

			monthlyRepayment = Math.Round((Double)monthlyRepayment, 2);
			monthlyRepTextBox.Text = monthlyRepayment.ToString("C");
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
