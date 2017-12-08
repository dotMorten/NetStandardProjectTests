using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetStandardTests.UI
{
    /// <summary>
    /// Custom platform control for Android
    /// </summary>
    public class MyControl : LinearLayout
    {
        private SharedClass sharedClass;
        private TextView tv;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyControl"/> class
        /// </summary>
        public MyControl() : this(Android.App.Application.Context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyControl"/> class
        /// </summary>
        /// <param name="context">Context</param>
        public MyControl(Android.Content.Context context) : base(context)
        {
            tv = new TextView(context);
            AddView(tv);
        }

        /// <summary>
        /// Gets or sets the test property
        /// </summary>
        public SharedClass MyProperty
        {
            get { return sharedClass; }
            set
            {
                sharedClass = value;
                tv.Text = value?.Test() ?? "";
                tv.SetTextColor(new Android.Graphics.Color(value.Color.ToArgb()));
            }
        }
    }
}
