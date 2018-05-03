
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
    [Activity(Label = "ReflectionActivity")]
    public class ReflectionActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //create custom list view
            // populate list view with data from journal entries table 
        }
    }
}
