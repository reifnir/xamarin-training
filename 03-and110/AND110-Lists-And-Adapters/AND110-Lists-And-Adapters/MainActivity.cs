using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Content;
using System;

namespace AND110ListsAndAdapters
{
    [Activity(Label = "Instructors", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var list = FindViewById<ListView>(Resource.Id.instructorViewList);

            //var adapter = new ArrayAdapter<Instructor>(this, Android.Resource.Layout.SimpleListItem1, InstructorData.Instructors);
            var instructors = new List<Instructor>();
            instructors.AddRange(InstructorData.Instructors);
            instructors.AddRange(InstructorData.Instructors);
            instructors.AddRange(InstructorData.Instructors);
            instructors.AddRange(InstructorData.Instructors);
            instructors.AddRange(InstructorData.Instructors);
            var adapter = new InstructorAdapter(instructors);
            list.Adapter = adapter;

            list.ItemClick += List_ItemClick;

            //copy of the instructors list
            //var instructors = InstructorData.Instructors.ToList();
            //var layoutFileId = 1;
            //list.Adapter = adapter;

        }

        void List_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var alert = new AlertDialog.Builder(this);

            var position = e.Position;

            alert.SetMessage(InstructorData.Instructors[position].ToString());
            alert.SetNeutralButton("OK", delegate { });
            alert.Show();
        }

    }
}

