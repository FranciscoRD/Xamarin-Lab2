//using Android.App;
//using Android.Widget;
//using Android.OS;

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace AndroidApp
{
    [Activity(Label = "AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Validate();
        }
        private async void Validate()
        {
            SALLab02.ServiceClient ServiceClient = new SALLab02.ServiceClient();
            string StudentEmail = "francisco_renan-dt@hotmail.com";
            string Password = "zxxzpa6413";
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            //string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, AndroidApp.Provider.Settings.Secure.AndroidId);
            SALLab02.ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
            Android.App.AlertDialog.Builder Builder = new AlertDialog.Builder(this);
            AlertDialog Alert = Builder.Create();
            Alert.SetTitle("Resulltado de la verificacion");
            Alert.SetIcon(Resource.Drawable.Icon);
            Alert.SetMessage($"{Result.Status}\n{Result.Fullname}\n{Result.Token}");
            Alert.SetButton("OK",(s,ev)=> { });
            Alert.Show();
        }
    }
}

