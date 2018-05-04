
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
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        ImageButton ibtnHome;
        ImageButton ibtnJournal;
        ImageButton ibtnReflection;


        protected override void OnCreate(Bundle savedInstanceState)

        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Menu);
            ibtnHome = FindViewById<ImageButton>(Resource.Id.ibtnHome);
            ibtnJournal = FindViewById<ImageButton>(Resource.Id.ibtnJournal);
            ibtnReflection = FindViewById<ImageButton>(Resource.Id.ibtnReflection);




            ibtnHome.Click += IbtnHome_Click;
            ibtnJournal.Click += IbtnJournal_Click;
            ibtnReflection.Click += IbtnReflection_Click;
            // Create your application here
        }

        void IbtnHome_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MotivationActivity));

        }

        void IbtnJournal_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(JournalActivity));
        }

        void IbtnReflection_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ReflectionActivity));
        }
    }
}
