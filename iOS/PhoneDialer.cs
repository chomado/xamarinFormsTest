using Foundation;
using Phoneword.iOS;
using UIKit;
using Xamarin.Forms;
using xamarinFormsTest;

[assembly: Dependency(typeof(PhoneDialer))]

namespace Phoneword.iOS
{
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + number));
        }
    }
}