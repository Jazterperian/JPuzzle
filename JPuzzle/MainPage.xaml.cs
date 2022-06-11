using System;
using System.IO;
using SkiaSharp;
using Xamarin.Forms;

namespace JPuzzle
{
    public partial class MainPage : ContentPage
    {
        public String[] str = new string[3];
        public MainPage() { InitializeComponent(); LB1F(); }

        async void BT1_Clicked(object sender, EventArgs e)
        {
            IPhotoLibrary photoLibrary = DependencyService.Get<IPhotoLibrary>();
            using (Stream stream = await photoLibrary.PickPhotoAsync())
            {
                if (stream != null)
                {
                    SKBitmap bitmap = SKBitmap.Decode(stream);

                    await Navigation.PushAsync(new EditPicture(/*bitmap*/));
                }
            }
        }
        void LB1F() { LB1.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(() => { DisplayAlert("Contact Us", "pablo.lll95@gmail.com", "OK"); }) }); }
    }
}
