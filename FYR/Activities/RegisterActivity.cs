
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

namespace FYR
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        EditText txtEmail;
        EditText txtMatchPassword; 
        Button btnCreate;
       //Button CreateAccount;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);

            btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtEmail = FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);
            txtMatchPassword = FindViewById<EditText>(Resource.Id.txtMatchPassword);

            btnCreate.Click+= BtnCreate_Click;
        }

void BtnCreate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == txtMatchPassword.Text)
            {
                try
                {
                    string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                    var db = new SQLite.SQLiteConnection(dbPath, true);
                    db.CreateTable<TableLogin>();
                    TableLogin tbl = new TableLogin();
                    tbl.username = txtUsername.Text;
                    tbl.email = txtEmail.Text;
                    tbl.password = txtPassword.Text;
                    db.Insert(tbl);
                    Toast.MakeText(this, "Account Created", ToastLength.Long).Show();

                    StartActivity(typeof(MotivationActivity));
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Passwords do not match", ToastLength.Long).Show(); 
            }
        }

    }
}
