using System;
using Android.Widget;

namespace AND110ListsAndAdapters
{
    public class ViewHolder : Java.Lang.Object
    {
        public ViewHolder(TextView name, TextView specialty, ImageView picture)
        {
            this.Name = name;
            this.Specialty = specialty;
            this.Picture = picture;
        }

        public TextView Name { get; }
        public TextView Specialty { get; }
        public ImageView Picture { get; }
    }
}
