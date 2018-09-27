using System;
using Android.App;
using Android.OS;
using Android.Runtime;
//using Android.Support.Design.Widget;
//using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Dining
{
    [Activity(Label = "@string/app_name", /*Theme = "@style/AppTheme.NoActionBar",*/ MainLauncher = true)]
    public class MainActivity : Activity
    {
        RecyclerView recyclerView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
        }
    }
}

