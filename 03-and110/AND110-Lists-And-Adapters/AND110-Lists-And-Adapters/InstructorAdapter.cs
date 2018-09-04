using System;
using System.Collections.Generic;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;

namespace AND110ListsAndAdapters
{
    public class InstructorAdapter : BaseAdapter<Instructor>
    {
        private readonly List<Instructor> instructors;
        public InstructorAdapter()
        {
        }
        public InstructorAdapter(List<Instructor> instructors)
        {
            this.instructors = instructors;
        }

        public override Instructor this[int position] => instructors[position];

        public override int Count => instructors.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var instructor = instructors[position];
            var inflater = LayoutInflater.From(parent.Context);
            var view = inflater.Inflate(Resource.Layout.InstructorRow, parent, false);

            var image = view.FindViewById<ImageView>(Resource.Id.photoImageView);
            //image.SetImageURI(Android.Net.Uri(instructor.ImageUrl));
            var drawable = Drawable.CreateFromStream(parent.Context.Assets.Open(instructor.ImageUrl), null);
            image.SetImageDrawable(drawable);

            var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
            name.Text = instructor.Name;

            var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);
            specialty.Text = instructor.Specialty;

            return view;
        }
    }
}
