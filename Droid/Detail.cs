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

namespace PCLNativeDemo.Droid
{
    [Activity(Label = "Detail")]
    public class Detail : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.detail);
            TextView txtName = FindViewById<TextView>(Resource.Id.txtName);
            TextView txtGender = FindViewById<TextView>(Resource.Id.txtGender);
            TextView txtCompany = FindViewById<TextView>(Resource.Id.txtCompany);
            TextView txtEmail = FindViewById<TextView>(Resource.Id.txtEmail);
            TextView txtPhone = FindViewById<TextView>(Resource.Id.txtPhone);
            TextView txtAddress = FindViewById<TextView>(Resource.Id.txtAddress);

            txtName.Text = Intent.GetStringExtra("name");
            txtGender.Text = Intent.GetStringExtra("gender");
            txtCompany.Text = Intent.GetStringExtra("company");
            txtEmail.Text = Intent.GetStringExtra("email");
            txtPhone.Text = Intent.GetStringExtra("phone");
            txtAddress.Text = Intent.GetStringExtra("address");
        }
    }
}
