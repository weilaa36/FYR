
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FYR.Classes;

namespace FYR.Activities
{
    [Activity(Label = "ReflectionActivity")]
    public class ReflectionActivity : Activity
    {
        ImageButton ibtnHome;
        ImageButton ibtnJournal;
        ImageButton ibtnReflection;

        public List<string> JournalEntries;
        ListView listReflect;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Reflection);

            listReflect = FindViewById<ListView>(Resource.Id.listReflect);

            //create connection 
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); // this calls the database
            var db = new SQLite.SQLiteConnection(dbPath, true);
            var data = db.Table<TableJournal>();

            JournalEntries = new List<string>();

            foreach (var item in data)
            {
                JournalEntries.Add(item.entry);
            }

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1,JournalEntries);

            listReflect.Adapter = adapter;
                
            ibtnHome = FindViewById<ImageButton>(Resource.Id.ibtnHome);
            ibtnJournal = FindViewById<ImageButton>(Resource.Id.ibtnJournal);
            ibtnReflection = FindViewById<ImageButton>(Resource.Id.ibtnReflection);


            ibtnHome.Click += IbtnHome_Click;
            ibtnJournal.Click += IbtnJournal_Click;
            ibtnReflection.Click += IbtnReflection_Click;


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
