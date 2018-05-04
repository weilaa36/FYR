
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


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Journal);

            txtJournalEntry = FindViewById<EditText>(Resource.Id.txtEntry);
            btnAddEntry = FindViewById<Button>(Resource.Id.btnAddEntry);


            btnAddEntry.Click+= BtnAddEntry_Click;
                
        }

        public void BtnAddEntry_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                    var db = new SQLite.SQLiteConnection(dbPath, true);
                    db.CreateTable<TableJournal>();
                    TableJournal tbl = new TableJournal();
                    tbl.entry = txtJournalEntry.Text;


                    db.Insert(tbl);
                    Toast.MakeText(this, "Entry Added", ToastLength.Long).Show();
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
                }
            }
            
        }

    }
}
