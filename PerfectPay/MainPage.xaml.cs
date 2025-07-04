﻿namespace PerfectPay
{
    public partial class MainPage : ContentPage
    {

        decimal bill;

        int tip;

        int noPersons = 1;


        public MainPage()
        {
            InitializeComponent();
        }

        private void txtBell_Completed(object sender, EventArgs e)
        {
            bill = decimal.Parse(txtBill.Text);

            CalculateTotal();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                var btn = (Button)sender;

                var percentage = int.Parse(btn.Text.Replace("%", ""));

                sldTip.Value = percentage;

            }

        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            tip = (int)sldTip.Value;

            lblTip.Text = $"Tip: {tip}%";

            CalculateTotal();
        }

        private void btnMinus_Clicked(object sender, EventArgs e)
        {
            if (noPersons > 1)
            {
                noPersons--;

            }

            lblNoPersons.Text = noPersons.ToString();

            CalculateTotal();
        }

        private void btnPlus_Clicked(object sender, EventArgs e)
        {
            noPersons++;

            lblNoPersons.Text = noPersons.ToString();

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            //total tip
            var totalTip =  (bill * tip) / 100 ;

            //tip by person
            var tipByPerson = (totalTip / noPersons);
            lblTipByPerson.Text = $"{tipByPerson:C}";

            //subTotal
            var subTotal = (bill / noPersons);
            lblSubtotal.Text = $"{subTotal:C}";

            //total
            var totalByPerson = (bill + totalTip) / noPersons;
            lblTotal.Text = $"{totalByPerson:C}";
        }
    }
}
