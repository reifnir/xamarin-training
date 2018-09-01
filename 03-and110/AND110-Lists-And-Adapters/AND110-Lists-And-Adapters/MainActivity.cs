using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;

namespace AND110ListsAndAdapters
{
    [Activity(Label = "AND110-Lists-And-Adapters", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };

            //copy of the instructors list
            var instructors = InstructorData.Instructors.ToList();
            var layoutFileId = 1;
            var adapter = new ArrayAdapter<Instructor>(this, layoutFileId, instructors);
            var list = FindViewById<ListView>(Resource.Id.instructors);
            list.Adapter = adapter;

        }
    }
}

