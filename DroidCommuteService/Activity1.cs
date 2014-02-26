using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using System.Json;

namespace DroidCommuteService
{
    [Activity(Label = "DroidCommuteService", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
           // DataAccess();
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button btnNavigate = FindViewById<Button>(Resource.Id.btnNavigate);
            //btnNavigate.Visibility = ViewStates.Invisible;
            btnNavigate.Click += (sender, e) =>
            {

                StartActivity(typeof(SecondActivity));

            };

            button.Click += delegate
            {
                Toast.MakeText(this, "This facility is underconstruction", ToastLength.Long).Show();

            };
        }
        private void DataAccess()
        {

            var rxcui = "198440";
            var request = HttpWebRequest.Create(string.Format(@"https://www.google.com/"));
            request.ContentType = "application/json";
            request.Method = "GET";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string strTest = "You are successful";
                }
            }
            //    HttpClient client = new HttpClient();
            //    client.BaseAddress = new Uri("http://localhost:56851/");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //    HttpResponseMessage message = client.GetAsync("api/Values/0").Result;
            //    if (message.IsSuccessStatusCode)
            //    {
            //        string strTest = "You are successful";
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}


        }
    }
}

