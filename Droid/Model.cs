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
    public class Model
    {
            public string _id { get; set; }
            public int index { get; set; }
            public string guid { get; set; }
            public bool isActive { get; set; }
            public string balance { get; set; }
            public string picture { get; set; }
            public int age { get; set; }
            public string eyeColor { get; set; }
            public string name { get; set; }
            public string gender { get; set; }
            public string company { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string address { get; set; }
       
    }
}