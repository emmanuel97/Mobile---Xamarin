using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using System.Collections;
using System;

namespace AndroidXamarin
{
    [Activity(Label = "AndroidXamarin", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button button;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            button = (Button)FindViewById(Resource.Id.button);
            
            button.Click += (sender, e) => {
                Viajar();
            };
        }

        public void Viajar()
        {
            var intent = new Intent(this, typeof(Activity2));
            StartActivity(intent);
        }

    }
}

