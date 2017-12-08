using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetStandardTests.UI
{
    public class MyControl : Android.Views.ViewGroup
    {
        private SharedClass sharedClass;
        private TextView tv;

        public MyControl() : this(Android.App.Application.Context) { }

        public MyControl(Android.Content.Context context) : base(context)
        {
            tv = new TextView(context);
            AddView(tv);
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);

            // Initialize dimensions of root layout
            MeasureChild(tv, widthMeasureSpec, MeasureSpec.MakeMeasureSpec(MeasureSpec.GetSize(heightMeasureSpec), MeasureSpecMode.AtMost));

            // Calculate the ideal width and height for the view
            var desiredWidth = PaddingLeft + PaddingRight + tv.MeasuredWidth;
            var desiredHeight = PaddingTop + PaddingBottom + tv.MeasuredHeight;

            // Get the width and height of the view given any width and height constraints indicated by the width and height spec values
            var width = ResolveSize(desiredWidth, widthMeasureSpec);
            var height = ResolveSize(desiredHeight, heightMeasureSpec);
            SetMeasuredDimension(width, height);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            tv.Layout(PaddingLeft, PaddingTop, tv.MeasuredWidth + PaddingLeft, tv.MeasuredHeight + PaddingBottom);
        }

        public SharedClass MyProperty
        {
            get { return sharedClass; }
            set
            {
                sharedClass = value;
                tv.Text = value?.ToString() ?? "";
                tv.SetTextColor(new Android.Graphics.Color(value.Color.ToArgb()));
            }
        }
    }
}
