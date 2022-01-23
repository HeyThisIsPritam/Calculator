using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private decimal firstNum;
        private string operatorName;
        private bool isOparetorClicked;
        
        private void BtnCommon_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if(LblResult.Text == "0" || isOparetorClicked)
            {
                isOparetorClicked = false;
                LblResult.Text= button.Text;
            }
            else
            {
                LblResult.Text += button.Text;
            }
        }

        private void BtnClear_Clicked(object sender , EventArgs e)
        {
            LblResult.Text = "0";
            isOparetorClicked=false;
            firstNum = 0;
        }

        private void BtnX_Clicked(object sender, EventArgs e)
        {
            string number = LblResult.Text;
            if(number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }

        public void BtnCommonOperation_Clicked(object sender,EventArgs e)
        {
            var button = sender as Button;
            isOparetorClicked = true;
            operatorName = button.Text;
            firstNum = Convert.ToDecimal(LblResult.Text);
        }

        private async void BtnPrecentage_Clicked(object sender , EventArgs e)
        {
            try
            {
                string number = LblResult.Text;
                if(number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue / 100).ToString("0.##");
                    LblResult.Text = result;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        private void BtnEqual_Clicked(object sender,EventArgs e)
        {
            try
            {
                decimal secondNum = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calculate(firstNum, secondNum).ToString("0.##");
                LblResult.Text = finalResult;
            }
            catch ( Exception ex)
            {

                DisplayAlert("Error", ex.Message, "Ok");
            }
        }
        public decimal Calculate(decimal firstNum , decimal secondNum )
        {
            decimal result = 0;
            if(operatorName == "+")
            {
                result =  firstNum + secondNum;
            }else if(operatorName == "-")
            {
                result= firstNum - secondNum;
            }else if(operatorName == "*")
            {
                result= secondNum * firstNum;
            }
            else if(operatorName == "/")
            {
                result= firstNum / secondNum;
            }
            return result;
            
        }
    }
}
