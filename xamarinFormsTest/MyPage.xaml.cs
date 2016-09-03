using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamarinFormsTest
{
    public partial class MyPage : ContentPage
    {
        string translatedNumber = "";

        public MyPage()
        {
            InitializeComponent();
        }

        void OnTranslate(object sender, EventArgs e)
        {
            translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            if (!string.IsNullOrEmpty(translatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + translatedNumber;
            }
            else {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        async void OnCall(object sender, EventArgs e)
        {
            bool alertDone = await this.DisplayAlert(
                title: "Dial a Number",
                message: "Would you like to call " + translatedNumber + "?",
                accept: "Yes",
                cancel: "No");

            if (alertDone)
            {
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(translatedNumber);
                }
            }
        }
    }
}
