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
            var view = convertView ?? inflater.Inflate(Resource.Layout.InstructorRow, parent, false);

            if (view.Tag as ViewHolder == null)
            {
                Console.WriteLine("New view!");
                var image = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);
                view.Tag = new ViewHolder(name, specialty, image);
            }
            var viewHolder = (ViewHolder)view.Tag;

            var drawable = ImageAssetManager.Get(parent.Context, instructor.ImageUrl);
            //image.SetImageURI(Android.Net.Uri(instructor.ImageUrl));
            viewHolder.Picture.SetImageDrawable(drawable);

            viewHolder.Name.Text = instructor.Name;

            viewHolder.Specialty.Text = instructor.Specialty;

            return view;
        }
    }
}
