using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NetStandardTests.Forms
{
    /// <summary>
    /// Xamarin.Forms Test Control
    /// </summary>
    public class MyControl : View
	{
        private NetStandardTests.UI.MyControl nativeControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyControl"/> class.
        /// </summary>
		public MyControl() : this(new NetStandardTests.UI.MyControl())
		{
        }

        private void Test()
        {
#if __IOS__
            var ios = MyProperty.IosProperty;
#elif __ANDROID__
            var android = MyProperty.AndroidProperty;            
#elif NETFX_CORE
            var uwp = MyProperty.UWPProperty;
#endif
#if XAMARIN
            var xamarin = MyProperty.XamarinProperty;
#endif
        }

        /// <summary>
        /// Gets a unique ID for the target framework
        /// </summary>
        /// <returns></returns>
        public int PlatformID()
        {
            int id = 0;
#if __IOS__
            id += MyProperty.IosProperty;
#elif __ANDROID__
            id += MyProperty.AndroidProperty;
#elif NETFX_CORE
            id +=  MyProperty.UWPProperty;
#endif
#if XAMARIN
            id += MyProperty.XamarinProperty;
#endif
            return id;
        }

        internal MyControl(NetStandardTests.UI.MyControl nativeControl)
        {
            this.nativeControl = nativeControl;
        }

        /// <summary>
        /// Gets or sets the test property
        /// </summary>
        public SharedClass MyProperty
        {
            get { return nativeControl.MyProperty; }
            set { nativeControl.MyProperty = value; }
        }
    }
}
