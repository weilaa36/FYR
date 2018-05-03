using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FYR.Activities
{
    [Activity(Label = "CategoryResolutionActivity")]
    public class CategoryResolutionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CategoryResolution);

            // pupluate list view from data in the category table to create drop down menu
        }
    }
}