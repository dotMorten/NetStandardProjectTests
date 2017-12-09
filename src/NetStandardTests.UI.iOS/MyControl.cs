using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using CoreGraphics;

namespace NetStandardTests.UI
{
    /// <summary>
    /// Custom platform control for iOS
    /// </summary>
    [Foundation.Register("MyControl")]
    [System.ComponentModel.DisplayName("MyControl")]
    public class MyControl : UILabel
    {
        private SharedClass sharedClass;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyControl"/> class
        /// </summary>
        /// <param name="p"></param>
        public MyControl(IntPtr p) : base(p)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyControl"/> class
        /// </summary>
        public MyControl()
        {
            Initialize();
        }

        /// <inheritdoc />
        public override void AwakeFromNib()
        {
            // Called when loaded from xib or storyboard.
            Initialize();
        }

        private void Initialize()
        {
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
                Text = value?.Test() ?? "";
                var color = value?.Color ?? System.Drawing.Color.Red;
                TextColor = UIColor.FromRGBA(color.R, color.G, color.G, color.A);
            }
        }
    }
}
