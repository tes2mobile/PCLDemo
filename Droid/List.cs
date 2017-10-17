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
using Android.Views.Animations;
using RecyclerViewAnimators.Animators;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

namespace PCLNativeDemo.Droid
{
    [Activity(Label = "List", MainLauncher = true, Icon = "@drawable/icon")]
    public class List : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            MobileCenter.Start("e67780b5-ce73-4898-9932-78adc99e961f",
                   typeof(Analytics), typeof(Crashes));
            SetContentView(Resource.Layout.list);

            Android.Support.V7.Widget.RecyclerView recyclerView = FindViewById<Android.Support.V7.Widget.RecyclerView>(Resource.Id.recyclerView);

            // improve performance if you know that changes in content
            // do not change the size of the RecyclerView
            recyclerView.HasFixedSize = true;

            // use a linear layout manager
            Android.Support.V7.Widget.LinearLayoutManager layoutManager = new Android.Support.V7.Widget.LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);

            List<RootObject> mytempObjet = MyClass.readDataFromFile();
            // specify an adapter
            RecyclarAdapter adapter = new RecyclarAdapter (this,mytempObjet);

            recyclerView.SetAdapter(adapter);
        }
    }

    public class RecyclarAdapter : Android.Support.V7.Widget.RecyclerView.Adapter
    {

        Activity activity;
        List<RootObject> items;

        public RecyclarAdapter(Activity activity, List<RootObject> items)
        {
            this.items = items;
            this.activity = activity;
        }

        // Create new views (invoked by the layout manager)
        public override Android.Support.V7.Widget.RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //Setup and inflate your layout here
            var id = Resource.Layout.item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            return new RecyclarViewHolder(itemView);
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(Android.Support.V7.Widget.RecyclerView.ViewHolder viewHolder, int position)
        {
            var holder = viewHolder as RecyclarViewHolder;
            var item = items[position];
            var objetAtIndex = items[position];
            holder.TextHeader.Text = objetAtIndex.name;
            holder.txtSubtitle.Text = objetAtIndex.company;
            holder.llContainer.Click += delegate {
                Intent intent = new Intent(activity, typeof(Detail));
                intent.PutExtra("name", objetAtIndex.name);
                intent.PutExtra("gender", objetAtIndex.gender);
                intent.PutExtra("company", objetAtIndex.company);
                intent.PutExtra("email", objetAtIndex.email);
                intent.PutExtra("phone", objetAtIndex.phone);
                intent.PutExtra("address", objetAtIndex.address);
                intent.AddFlags(ActivityFlags.NewTask);
                activity.ApplicationContext.StartActivity(intent);
            };
        }

        public override int ItemCount
        {
            get
            {
                return items.Count();
            }
        }
    }


    public class RecyclarViewHolder : Android.Support.V7.Widget.RecyclerView.ViewHolder
    {
       // public ImageView Image { get; private set; }
        public TextView TextHeader { get; private set; }
        public TextView txtSubtitle { get; private set; }
        public LinearLayout llContainer { get; private set; }

        public RecyclarViewHolder(View itemView) : base(itemView)
        {
            TextHeader = itemView.FindViewById<TextView>(Resource.Id.txtHeader);
            txtSubtitle = itemView.FindViewById<TextView>(Resource.Id.txtSubtitle);
            llContainer = itemView.FindViewById<LinearLayout>(Resource.Id.llContainer);
          
        }
    }
}