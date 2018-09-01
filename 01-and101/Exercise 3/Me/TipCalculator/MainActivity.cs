using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace TipCalculator
{
	[Activity(Label = "TipCalculator", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;

        protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);
            calculateButton.Click += OnCalculateClick;
        }

        private void OnCalculateClick(object sender, System.EventArgs e)
        {
            var billText = inputBill.Text;
            var billTotal = double.Parse(billText);

            var tip = Math.Round((billTotal * 0.2), 2);
            var totalPayment = billTotal + tip;

            outputTip.Text = tip.ToString();
            outputTotal.Text = totalPayment.ToString();
        }
    }
}