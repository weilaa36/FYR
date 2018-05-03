using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.IO;
using System;
using FYR.Classes;

namespace FYR
{
    [Activity(Label = "FYR", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText txtUsername;
        EditText txtPassword;
        Button btnLogin;
        Button btnRegister;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            btnLogin.Click+= BtnLogin_Click;
            btnRegister.Click+= BtnRegister_Click;


        }

        void BtnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); // this calls the database
                var db = new SQLite.SQLiteConnection(dbPath, true);
                var data = db.Table<TableLogin>();

                //var data1 = data;

                //var userFound = false;


                // Toast.MakeText(this, "UI Username: " + txtUsername.Text, ToastLength.Short).Show();
                //Toast.MakeText(this, "UI Password: " + txtPassword.Text, ToastLength.Short).Show();

                //foreach (var d in data)
                //{

                //    //Toast.MakeText(this, "UserName: " + d.username, ToastLength.Short).Show();
                //    //Toast.MakeText(this, "Password: " + d.password, ToastLength.Short).Show();

                //    if ((d.username == txtUsername.Text) && (d.password == txtPassword.Text) )
                //    {
                //        //Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                //        // match found
                //        userFound = true;
                //        //Toast.MakeText(this, "userfound: " + userFound.ToString(), ToastLength.Short).Show();
                //    }
                //}



                //Toast.MakeText(this, data<LoginTable>.ToString(), ToastLength.Long).Show();

                //Toast.MakeText(this, "userfound: " + userFound.ToString(), ToastLength.Short).Show();

                //if (userFound)

                var data1 = data.Where(x => x.username == txtUsername.Text && x.password == txtPassword.Text).FirstOrDefault(); //Ling Query
                if (data1 != null)
                {
                    StartActivity(typeof(MotivationActivity));

                }

                else
                {
                    Toast.MakeText(this, "Please enter a valid Username and Password", ToastLength.Short).Show();
                }
            }

            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }

        void BtnRegister_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(RegisterActivity));
        }

        public string CreateDB()
        {
            var output = "";
            output += "Creating Database if it Doesn't Exist";
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Create new Database
            var db = new SQLite.SQLiteConnection(dbPath, true);
            output += "\n Database Created...";
            return output;

        }

    }

    }