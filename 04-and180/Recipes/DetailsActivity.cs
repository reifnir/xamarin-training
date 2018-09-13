using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Recipes
{
	[Activity(Label = "DetailsActivity")]
	public class DetailsActivity : Activity //Android.Support.V7.App.AppCompatActivity
    {
		Recipe recipe;
		ArrayAdapter adapter;
        Toolbar toolbar;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Details);

			//
			// Retrieve the recipe to be displayed on this page
			//
			int index = Intent.GetIntExtra("RecipeIndex", -1);
			recipe = RecipeData.Recipes[index];

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.Title = recipe.Name;

            base.SetActionBar(toolbar);

            //Show menu button in top left toolbar location
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_arrow_back_white_24dp);

            //
            // Show the list of ingredients
            //
            var list = FindViewById<ListView>(Resource.Id.ingredientsListView);
			list.Adapter = adapter = new ArrayAdapter<Ingredient>(this, Android.Resource.Layout.SimpleListItem1, recipe.Ingredients);

        }

        //
        // Handler for the 'favorite' toggle button
        //
        void OnFavoriteCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			recipe.IsFavorite = e.IsChecked; // update the recipe's state

			SetFavoriteDrawable(e.IsChecked); // toggle the image used on the button
		}

		void SetFavoriteDrawable(bool isFavorite)
		{
            var favoriteIcon = (isFavorite)
                ? Resource.Drawable.ic_favorite_white_24dp
                : Resource.Drawable.ic_favorite_border_white_24dp;

            //if (isFavorite)
            //	drawable = base.GetDrawable(Resource.Drawable.ic_favorite_white_24dp); // filled in 'heart' image
            //else
            //	drawable = base.GetDrawable(Resource.Drawable.ic_favorite_border_white_24dp); // 'heart' image border only
            var addToFavorites = toolbar.Menu.FindItem(Resource.Id.addToFavorites);
            addToFavorites.SetIcon(favoriteIcon);
			//FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
		}
		// Note: base.GetDrawable requires API level 21
		// To run on earlier versions, change the minimum API level in the project settings and use the following code:
		//void SetFavoriteDrawables(bool isFavorite)
		//{
		//	Drawable drawable = null;
		//
		//	if (isFavorite)
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_white_24dp);
		//	else
		//		drawable = Resources.GetDrawable(Resource.Drawable.ic_favorite_border_white_24dp);
		//
		//	FindViewById<ToggleButton>(Resource.Id.favoriteButton).SetCompoundDrawablesWithIntrinsicBounds(null, drawable, null, null);
		//}

		void SetServings(int numServings)
		{
			recipe.NumServings = numServings;

			adapter.NotifyDataSetChanged();
		}

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.MenuInflater.Inflate(Resource.Menu.recipeMenu, menu);
            SetFavoriteDrawable(recipe.IsFavorite);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    break;
                case Resource.Id.addToFavorites:
                    recipe.IsFavorite = !recipe.IsFavorite;
                    SetFavoriteDrawable(recipe.IsFavorite);
                    break;
                case Resource.Id.about:
                    StartActivity(typeof(AboutActivity));
                    break;
                //case Resource.Id.servings:                    
                //    e.Item.SubMenu.FindItem(Resource.Id.oneServing).SetChecked(recipe.NumServings == 1);
                //    break;
                case Resource.Id.oneServing:
                    SetServings(1);
                    item.SetChecked(true);
                    break;
                case Resource.Id.twoServings:
                    SetServings(2);
                    item.SetChecked(true);
                    break;
                case Resource.Id.fourServings:
                    SetServings(4);
                    item.SetChecked(true);
                    break;
            }
            return true;
        }

    }
}