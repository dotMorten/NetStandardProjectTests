using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using CoreGraphics;

namespace NetStandardTests.UI
{
    [Foundation.Register("MyControl")]
    [System.ComponentModel.DisplayName("MyControl")]
    public class MyControl : UIView
    {
        private SharedClass sharedClass;
        private UILabel text;

        public MyControl()
        {
            text = new UILabel();
            AddSubview(text);
        }
        
        public SharedClass MyProperty
        {
            get { return sharedClass; }
            set
            {
                sharedClass = value;
                text.Text = value?.ToString() ?? "";
                var color = value?.Color ?? System.Drawing.Color.Red;
                text.TextColor = UIColor.FromRGBA(color.R, color.G, color.G, color.A);
                InvalidateIntrinsicContentSize();
            }
        }
    }
}
