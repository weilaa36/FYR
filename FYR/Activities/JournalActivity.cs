
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
    [Activity(Label = "JournalActivity")]
    public class JournalActivity : Activity
    {
        EditText txtJournalEntry;
        Button btnAddEntry;

        ImageButton ibtnHome;
        ImageButton ibtnJournal;
        ImageButton ibtnReflection;



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Journal);

            txtJournalEntry = FindViewById<EditText>(Resource.Id.txtJournalEntry);
            btnAddEntry = FindViewById<Button>(Resource.Id.btnAddEntry);


            btnAddEntry.Click+= BtnAddEntry_Click;

            ibtnHome = FindViewById<ImageButton>(Resource.Id.ibtnHome);
            ibtnJournal = FindViewById<ImageButton>(Resource.Id.ibtnJournal);
            ibtnReflection = FindViewById<ImageButton>(Resource.Id.ibtnReflection);



            ibtnHome.Click += IbtnHome_Click;
            ibtnJournal.Click += IbtnJournal_Click;
            ibtnReflection.Click += IbtnReflection_Click;

            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLite.SQLiteConnection(dbPath, true);
                db.CreateTable<TableJournal>();
                //TableJournal tbl = new JournalTable();
                //var data = db.Table<TableJournal>();
                //JournalEntries = new List<string>();

                //foreach (var entries in data)
                //{
                // JournalEntries.Add(entries.entry);
                //}

                //tbl.entry = txtJournalEntry.Text;
                //db.Insert(tbl);
               
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }

        public void BtnAddEntry_Click(object sender, EventArgs e)
        {
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLite.SQLiteConnection(dbPath, true);
                var newEntry = new TableJournal { entry = txtJournalEntry.Text };
                db.Insert(newEntry);

                Toast.MakeText(this, "Entry Added", ToastLength.Long).Show();
            }
            
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
