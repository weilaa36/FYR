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

namespace FYR
{
    [Activity(Label = "MotivationActivity")]
    public class MotivationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Motivation);
            // Design custom list view 
            // popluate with data from goalpost table in the database

        }
    }
}