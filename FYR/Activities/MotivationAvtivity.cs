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
using FYR.Activities;
using System.Collections;

namespace FYR
{
    [Activity(Label = "MotivationActivity")]
    public class MotivationActivity : Activity
    {
        int selector;
        Button bAdd;
        TextView display;
        ArrayList listOfRandomQuotes;

        ImageButton ibtnHome;
        ImageButton ibtnJournal;
        ImageButton ibtnReflection;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Motivation);

            listOfRandomQuotes = new ArrayList();
            listOfRandomQuotes.Add("A penny saved is a penny earned.");
            listOfRandomQuotes.Add("Only I can change my life.");
            listOfRandomQuotes.Add("Life is 10% what happens to you and 90% how you react to it.");
            listOfRandomQuotes.Add("Good, better, best.");
            listOfRandomQuotes.Add("Optimism is the faith that leads to achievement.");
            listOfRandomQuotes.Add("I have decided to stick with love. Hate is too great a burden to bear.");
            listOfRandomQuotes.Add("With the new day comes new strength and new thoughts.");
            listOfRandomQuotes.Add("You must be the change you wish to see in the world.");
            listOfRandomQuotes.Add("The past cannot be changed.");
            listOfRandomQuotes.Add("Failure will never overtake me if my determination to succeed is strong enough.");
            listOfRandomQuotes.Add("The bird is powered by its own life and by its motivation.");
            listOfRandomQuotes.Add("It is in your moments of decision that your destiny is shaped.");
            listOfRandomQuotes.Add("When you have a dream, you've got to grab it and never let go.");
            listOfRandomQuotes.Add("There are two ways of spreading light: to be the candle or the mirror that reflects it.");

            bAdd = FindViewById<Button>(Resource.Id.bAdd);
            display = FindViewById<TextView>(Resource.Id.tvDisplay);

            bAdd.Click += bAdd_Click;

            ibtnHome = FindViewById<ImageButton>(Resource.Id.ibtnHome);
            ibtnJournal = FindViewById<ImageButton>(Resource.Id.ibtnJournal);
            ibtnReflection = FindViewById<ImageButton>(Resource.Id.ibtnReflection);



            ibtnHome.Click += IbtnHome_Click;
            ibtnJournal.Click += IbtnJournal_Click;
            ibtnReflection.Click += IbtnReflection_Click;

        }

void bAdd_Click(object sender, EventArgs e)
        {
            Random randomNumber = new Random();
            selector = randomNumber.Next(13);
            display.Text = listOfRandomQuotes[selector].ToString();
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