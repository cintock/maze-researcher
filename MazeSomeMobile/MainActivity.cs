using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Maze.Logic;

namespace MazeSomeMobile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private void ShowNewMaze()
        {
            IMazeGenerator gen = new EllerModMazeGenerator();
            IMazeView maze = gen.Generate(35, 35);
            IMazeDrawer drawer = new SimpleMazeDrawer();
            byte[] image = drawer.Draw(maze);

            Bitmap shownImage = BitmapFactory.DecodeByteArray(image, 0, image.Length);
            ImageView myImageView = FindViewById<ImageView>(Resource.Id.myImageView);
            myImageView.SetImageBitmap(shownImage);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            ShowNewMaze();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            ShowNewMaze();
            View view = (View) sender;
            Snackbar.Make(view, "Создан новый лабиринт", Snackbar.LengthShort)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

