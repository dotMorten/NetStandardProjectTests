using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using CoreGraphics;

namespace NetStandardTests.UI
{
    public class MyControl : UIView
    {
        private SharedClass sharedClass;
        public MyControl()
        {
        }


        public SharedClass MyProperty
        {
            get { return sharedClass; }
            set
            {
                sharedClass = value;
                // tv.Text = value?.ToString() ?? "";
                // tv.SetTextColor(new Android.Graphics.Color(value.Color.ToArgb()));
            }
        }
    }
}
