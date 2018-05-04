
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

            ArrayAdapter<TableJournal> adapter = new ArrayAdapter<TableJournal>(this, Android.Resource.Layout.SimpleListItem1);

            listReflect.Adapter = adapter;


        }

    }
}
